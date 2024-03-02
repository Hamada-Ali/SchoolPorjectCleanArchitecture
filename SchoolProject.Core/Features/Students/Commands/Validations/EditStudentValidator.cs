using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Students.Commands.Validations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _service;

        public EditStudentValidator(IStudentService service)
        {
            ApplyValidationRules();
            ApplyCustomeValidationRules();
            _service = service;
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("field can't be null")
                .MaximumLength(40).WithMessage("MAX LENGTH IS 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null")
                .MaximumLength(40).WithMessage("{PropertyName} LENGTH IS 10");

        }

        public void ApplyCustomeValidationRules()
        {
            RuleFor(x => x.NameEn)
                .MustAsync(async (model, Key, CancellationToken) => !await _service.IsNameExistExcludeSelf(model.Id, Key))
                .WithMessage("Name is Exist");
        }
    }
}
