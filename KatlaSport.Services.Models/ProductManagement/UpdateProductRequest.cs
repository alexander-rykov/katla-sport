using FluentValidation.Attributes;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a request for creating and updating a product.
    /// </summary>
    [Validator(typeof(UpdateProductRequestValidator))]
    public class UpdateProductRequest
    {
        /// <summary>
        /// Gets or sets a product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a product code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a product category identifier.
        /// </summary>
        public int CategoryId { get; set; }

        // TODO STEP 2 - Add "Description", "ManufacturerCode" and "Price" properties here.
    }
}
