using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Students.Commands.Validations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _service;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public AddStudentValidator(IStudentService service, IStringLocalizer<SharedResources> stringLocalizer)
        {
            ApplyValidationRules();
            ApplyCustomeValidationRules();
            _service = service;
            _stringLocalizer = stringLocalizer;
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage("can't be empty")
                .NotNull().WithMessage("field can't be null")
                .MaximumLength(10).WithMessage("MAX LENGTH IS 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null")
                .MaximumLength(10).WithMessage("{PropertyName} LENGTH IS 10");

        }

        public void ApplyCustomeValidationRules()
        {
            RuleFor(x => x.NameEn)
                .MustAsync(async (Key, CancellationToken) => !await _service.IsNameExist(Key))
                .WithMessage("Name is Exist");
        }
    }
}
