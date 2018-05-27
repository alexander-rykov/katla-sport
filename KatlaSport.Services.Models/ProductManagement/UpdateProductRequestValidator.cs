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

            RuleFor(r => r.Description).Length(0, 300);
            RuleFor(r => r.ManufacturerCode).Length(4, 10);
            RuleFor(r => r.Price).GreaterThanOrEqualTo(0);
        }
    }
}
