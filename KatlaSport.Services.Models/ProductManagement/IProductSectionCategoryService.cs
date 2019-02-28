using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a hive section category service.
    /// </summary>
    public interface IProductSectionCategoryService
    {
        /// <summary>
        /// Gets a list of products categories in hive section.
        /// </summary>
        /// <param name="sectionId">A section modifier.</param>
        /// <returns>A <see cref="Task{TResult}"/></returns>
        Task<List<ProductCategoryListItem>> GetSectionCategoriesAsync(int sectionId);
    }
}