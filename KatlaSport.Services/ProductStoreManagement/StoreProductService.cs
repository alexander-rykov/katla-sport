using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductCatalogue;
using KatlaSport.DataAccess.ProductStore;
using KatlaSport.Services.ProductManagement;

namespace KatlaSport.Services.ProductStoreManagement
{
    public class StoreProductService : IStoreProductService
    {
        //private readonly IUserContext _userContext;
        private readonly IProductStoreContext _storeContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreProductService"/> class with specified <see cref="IProductCatalogueContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductCatalogueContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public StoreProductService(IProductStoreContext context)
        {
            _storeContext = context ?? throw new ArgumentNullException();
            //_userContext = userContext ?? throw new ArgumentNullException();
        }

        public async Task<List<ProductStoreItem>> GetItemsAsync()
        {
            var dbItems = await _storeContext.Items.OrderBy(h => h.Id).ToArrayAsync();
            var items = dbItems.Select(h => Mapper.Map<ProductStoreItem>(h)).ToList();

            foreach (ProductStoreItem item in items)
            {
                item.HiveSectionId = _storeContext.Items.Count(s => s.ProductId == item.Id);
            }

            return items;
        }

        public async Task<ProductStoreItem> GetItemAsync(int productId)
        {
            var dbProducts = await _storeContext.Items.Where(p => p.Id == productId).ToArrayAsync();

            if (dbProducts.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<StoreItem, ProductStoreItem>(dbProducts[0]);
        }

        public Task DeleteItemAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task SetStatusAsync(int productId, bool deletedStatus)
        {
            throw new NotImplementedException();
        }
    }
}