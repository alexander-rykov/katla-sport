using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductCatalogue;
using DbProductCategory = KatlaSport.DataAccess.ProductCatalogue.ProductCategory;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a product category service.
    /// </summary>
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCatalogueContext _context;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategoryService"/> class with specified <see cref="IProductCatalogueContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductCatalogueContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public ProductCategoryService(IProductCatalogueContext context, IUserContext userContext)
        {
            _context = context ?? throw new ArgumentNullException();
            _userContext = userContext ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<List<ProductCategoryListItem>> GetCategoriesAsync(int start, int amount)
        {
            var dbCategories = await _context.Categories.OrderBy(c => c.Id).Skip(start).Take(amount).ToListAsync();
            var categories = dbCategories.Select(c => Mapper.Map<ProductCategoryListItem>(c)).ToList();

            foreach (var c in categories)
            {
                c.ProductCount = await _context.Products.Where(p => p.CategoryId == c.Id).CountAsync();
            }

            return categories;
        }

        /// <inheritdoc/>
        public async Task<ProductCategory> GetCategoryAsync(int categoryId)
        {
            var dbCategories = await _context.Categories.Where(p => p.Id == categoryId).ToArrayAsync();

            if (dbCategories.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbProductCategory, ProductCategory>(dbCategories[0]);
        }

        /// <inheritdoc/>
        public async Task<ProductCategory> CreateCategoryAsync(UpdateProductCategoryRequest createRequest)
        {
            var dbCategories = await _context.Categories.Where(c => c.Code == createRequest.Code).ToArrayAsync();
            if (dbCategories.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var dbCategory = Mapper.Map<UpdateProductCategoryRequest, DbProductCategory>(createRequest);
            dbCategory.CreatedBy = _userContext.UserId;
            dbCategory.LastUpdatedBy = _userContext.UserId;
            _context.Categories.Add(dbCategory);

            await _context.SaveChangesAsync();

            return Mapper.Map<ProductCategory>(dbCategory);
        }

        /// <inheritdoc/>
        public async Task<ProductCategory> UpdateCategoryAsync(int categoryId, UpdateProductCategoryRequest updateRequest)
        {
            var dbCategories = await _context.Categories.Where(c => c.Code == updateRequest.Code && c.Id != categoryId).ToArrayAsync();
            if (dbCategories.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbCategories = await _context.Categories.Where(c => c.Id == categoryId).ToArrayAsync();
            var dbCategory = dbCategories.FirstOrDefault();
            if (dbCategory == null)
            {
                throw new RequestedResourceNotFoundException();
            }

            Mapper.Map(updateRequest, dbCategory);
            dbCategory.LastUpdatedBy = _userContext.UserId;

            await _context.SaveChangesAsync();

            dbCategories = await _context.Categories.Where(c => c.Id == categoryId).ToArrayAsync();
            return dbCategories.Select(c => Mapper.Map<ProductCategory>(c)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task DeleteCategoryAsync(int categoryId)
        {
            var dbCategories = await _context.Categories.Where(c => categoryId == c.Id).ToArrayAsync();

            if (dbCategories.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbCategory = dbCategories[0];
            if (dbCategory.IsDeleted == false)
            {
                throw new RequestedResourceHasConflictException();
            }

            _context.Categories.Remove(dbCategory);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task SetStatusAsync(int categoryId, bool deletedStatus)
        {
            var dbCategories = await _context.Categories.Where(c => categoryId == c.Id).ToArrayAsync();

            if (dbCategories.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbCategory = dbCategories[0];
            if (dbCategory.IsDeleted != deletedStatus)
            {
                dbCategory.IsDeleted = deletedStatus;
                dbCategory.LastUpdated = DateTime.UtcNow;
                dbCategory.LastUpdatedBy = _userContext.UserId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
