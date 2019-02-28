using AutoMapper;
using KatlaSport.DataAccess.ProductStore;
using KatlaSport.Services.ProductManagement;

namespace KatlaSport.Services.ProductStoreManagement
{
    public class ProductStoreManagementMappingProfile : Profile
    {
        public ProductStoreManagementMappingProfile()
        {
            CreateMap<StoreItem, ProductStoreItem>();
            CreateMap<StoreItem, ProductListItem>();
            CreateMap<ProductStoreItem, ProductListItem>();
        }
    }
}