using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authorization.Commands.Validator
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {

        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public EditRoleValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomeValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
        }

        public void ApplyCustomeValidationRules()
        {

        }
    }
}
