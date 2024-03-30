using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.IdentityUser.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.IdentityUser.Commands.Validators
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public ChangeUserPasswordValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            //ApplyCustomeValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword).WithMessage(_stringLocalizer[SharedResourcesKeys.PasswordNotEqualConfirmPassword]);

        }
    }
}
