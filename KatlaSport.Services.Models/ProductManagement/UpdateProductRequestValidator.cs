using FluentValidation;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateProductRequest"/>.
    /// </summary>
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProductRequestValidator"/> class.
        /// </summary>
        public UpdateProductRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 60);
            RuleFor(r => r.Code).Length(5);
            RuleFor(r => r.CategoryId).GreaterThan(0);

            // TODO STEP 2 - Add rules for "Description", "ManufacturerCode" and "Price" here.
        }
    }
}
