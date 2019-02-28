using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStoreHive;

namespace KatlaSport.Services.ProductManagement
{
    public class ProductSectionCategoryService : IProductSectionCategoryService
    {
        private readonly IProductStoreHiveContext _context;

        /// <inheritdoc />
        public ProductSectionCategoryService(IProductStoreHiveContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc />
        public async Task<List<ProductCategoryListItem>> GetSectionCategoriesAsync(int sectionId)
        {
            var hiveSections = await _context.Sections.Where(section => section.Id == sectionId)
                .ToArrayAsync();
            if (hiveSections.Length == 0)
            {
                throw new RequestedResourceHasConflictException();
            }

            var dbCategories = hiveSections[0].Categories.ToList();
            var sectionCategories = dbCategories.Select(category => Mapper.Map<ProductCategoryListItem>(category.Category)).ToList();

            return sectionCategories;
        }
    }
}