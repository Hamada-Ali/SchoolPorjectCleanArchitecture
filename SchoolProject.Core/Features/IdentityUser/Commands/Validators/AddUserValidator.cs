using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.IdentityUser.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.IdentityUser.Commands.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public AddUserValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            //ApplyCustomeValidationRules();
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

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage(_stringLocalizer[SharedResourcesKeys.PasswordNotEqualConfirmPassword]);

        }

        //public void ApplyCustomeValidationRules()
        //{
        //    RuleFor(x => x.NameAr)
        //        .MustAsync(async (Key, CancellationToken) => !await _service.IsNameExist(Key))
        //        .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        //    RuleFor(x => x.NameEn)
        //        .MustAsync(async (Key, CancellationToken) => !await _service.IsNameExist(Key))
        //        .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        //    RuleFor(x => x.DepartmentId)
        //        .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentExist(Key))
        //        .WithMessage(_stringLocalizer[SharedResourcesKeys.DepartmentIdNotExist]);
        //}

    }
}
