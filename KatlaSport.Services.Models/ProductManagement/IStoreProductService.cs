using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ProductManagement
{
    public interface IStoreProductService
    {
        Task<List<ProductStoreItem>> GetItemsAsync();

        Task<ProductStoreItem> GetItemAsync(int productId);

        Task DeleteItemAsync(int productId);

        Task SetStatusAsync(int productId, bool deletedStatus);
    }
}