using System.Collections.Generic;

namespace KatlaSport.Services.CatalogueManagement
{
    /// <summary>
    /// Represents a catalogue manager service.
    /// </summary>
    public interface ICatalogueManagementService
    {
        IList<Category> GetProductCategories();

        void AddProductCategory();
    }
}
