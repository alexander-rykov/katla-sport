using FluentValidation;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateHiveSectionRequest"/>
    /// </summary>
    public class UpdateHiveSectionRequestValidator : AbstractValidator<UpdateHiveSectionRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateHiveSectionRequestValidator"/> class.
        /// </summary>
        public UpdateHiveSectionRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 60);
            RuleFor(r => r.Code).Length(5);
            RuleFor(r => r.HiveId).GreaterThan(0);
        }
    }
}
