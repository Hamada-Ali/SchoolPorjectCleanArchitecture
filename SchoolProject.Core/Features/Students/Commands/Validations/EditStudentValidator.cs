using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Students.Commands.Validations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _service;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public EditStudentValidator(IStudentService service, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _service = service;
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomeValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                .MaximumLength(40).WithMessage("MAX LENGTH IS 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
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
