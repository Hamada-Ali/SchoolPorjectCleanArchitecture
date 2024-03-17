using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.IdentityUser.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.IdentityUser.Commands.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public UpdateUserValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                .MaximumLength(20).WithMessage("MAX LENGTH IS 20");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                .MaximumLength(20).WithMessage("{PropertyName} LENGTH IS 20");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

        }
    }
}
