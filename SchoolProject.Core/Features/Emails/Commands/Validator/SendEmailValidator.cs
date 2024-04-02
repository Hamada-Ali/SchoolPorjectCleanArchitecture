using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Emails.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Emails.Commands.Validator
{
    public class SendEmailValidator : AbstractValidator<SendEmailCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public SendEmailValidator(IStudentService service, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            //ApplyCustomeValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

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
