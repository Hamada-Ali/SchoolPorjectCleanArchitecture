using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Instructors.command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Instructors.command.Validator
{
    public class AddInstructorValidator : AbstractValidator<AddInstructorCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;
        private readonly IInstructorService _instructorService;

        public AddInstructorValidator(IStringLocalizer<SharedResources> stringLocalizer, IDepartmentService departmentService,
            IInstructorService instructorService)
        {
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
            _instructorService = instructorService;
            ApplyCustomeValidationRules();
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                .MaximumLength(20).WithMessage("MAX LENGTH IS 20");

            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                .MaximumLength(20).WithMessage("{PropertyName} LENGTH IS 20");

            RuleFor(x => x.DID)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

        }


        public void ApplyCustomeValidationRules()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (Key, CancellationToken) => !await _instructorService.IsNameExistAr(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
                .MustAsync(async (Key, CancellationToken) => !await _instructorService.IsNameExistEn(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);


            RuleFor(x => x.DID)
                .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentExist(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.DepartmentIdNotExist]);
        }

    }
}
