using FluentValidation;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateProductCategoryRequest"/>.
    /// </summary>
    public class UpdateProductCategoryRequestValidator : AbstractValidator<UpdateProductCategoryRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProductCategoryRequestValidator"/> class.
        /// </summary>
        public UpdateProductCategoryRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 60);
            RuleFor(r => r.Code).Length(5);
            RuleFor(r => r.Description).Length(0, 300);
        }
    }
}
