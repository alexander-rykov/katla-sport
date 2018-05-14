using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductCatalogue;
using DbProduct = KatlaSport.DataAccess.ProductCatalogue.CatalogueProduct;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a product catalogue service.
    /// </summary>
    public class ProductCatalogueService : IProductCatalogueService
    {
        private readonly IProductCatalogueContext _context;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCatalogueService"/> class with specified <see cref="IProductCatalogueContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductCatalogueContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public ProductCatalogueService(IProductCatalogueContext context, IUserContext userContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        /// <inheritdoc/>
        public async Task<List<ProductListItem>> GetProductsAsync(int start, int amount)
        {
            var dbProducts = await _context.Products.OrderBy(p => p.Id).Skip(start).Take(amount).ToArrayAsync();
            var products = dbProducts.Select(p => Mapper.Map<ProductListItem>(p)).ToList();

            return products;
        }

        /// <inheritdoc/>
        public async Task<List<ProductCategoryProductListItem>> GetCategoryProductsAsync(int productCategoryId)
        {
            var dbCategories = await _context.Categories.Where(p => p.Id == productCategoryId).ToArrayAsync();
            if (dbCategories.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbProducts = await _context.Products.OrderBy(p => p.Id).Where(p => p.CategoryId == productCategoryId).ToArrayAsync();
            var products = dbProducts.Select(p => Mapper.Map<ProductCategoryProductListItem>(p)).ToList();

            return products;
        }

        /// <inheritdoc/>
        public async Task<Product> GetProductAsync(int productId)
        {
            var dbProducts = await _context.Products.Where(p => p.Id == productId).ToArrayAsync();

            if (dbProducts.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbProduct, Product>(dbProducts[0]);
        }

        /// <inheritdoc/>
        public async Task<Product> CreateProductAsync(UpdateProductRequest createRequest)
        {
            var dbProducts = await _context.Products.Where(p => p.Code == createRequest.Code).ToArrayAsync();
            if (dbProducts.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var dbProduct = Mapper.Map<UpdateProductRequest, DbProduct>(createRequest);
            dbProduct.CreatedBy = _userContext.UserId;
            dbProduct.LastUpdatedBy = _userContext.UserId;
            _context.Products.Add(dbProduct);

            await _context.SaveChangesAsync();

            return Mapper.Map<Product>(dbProduct);
        }

        /// <inheritdoc/>
        public async Task<Product> UpdateProductAsync(int productId, UpdateProductRequest updateRequest)
        {
            var dbProducts = await _context.Products.Where(p => p.Code == updateRequest.Code && p.Id != productId).ToArrayAsync();
            if (dbProducts.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbProducts = await _context.Products.Where(p => p.Id == productId).ToArrayAsync();
            if (dbProducts.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbProduct = dbProducts[0];

            Mapper.Map(updateRequest, dbProduct);
            dbProduct.LastUpdatedBy = _userContext.UserId;

            await _context.SaveChangesAsync();

            return Mapper.Map<Product>(dbProduct);
        }

        /// <inheritdoc/>
        public async Task DeleteProductAsync(int productId)
        {
            var products = await _context.Products.Where(p => p.Id == productId).ToArrayAsync();
            if (products.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var product = products[0];
            if (product.IsDeleted == false)
            {
                throw new RequestedResourceHasConflictException();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task SetStatusAsync(int productId, bool deletedStatus)
        {
            var products = await _context.Products.Where(p => productId == p.Id).ToArrayAsync();

            if (products.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbCategory = products[0];
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
