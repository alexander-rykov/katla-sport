using System;
using System.Collections.Generic;
using System.Linq;
using KatlaSport.DataAccess.ProductCatalogue;

namespace KatlaSport.Services.CatalogueManagement
{
    internal class CatalogueManagementService : ICatalogueManagementService
    {
        private readonly IProductCatalogueContext _catalogueContext;

        public CatalogueManagementService(IProductCatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext ?? throw new ArgumentNullException(nameof(catalogueContext));
        }

        public IList<Category> GetProductCategories()
        {
            var categories = _catalogueContext.Categories.ToArray();

            return categories.Select(c => new Category
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        public void AddProductCategory()
        {
        }
    }
}
