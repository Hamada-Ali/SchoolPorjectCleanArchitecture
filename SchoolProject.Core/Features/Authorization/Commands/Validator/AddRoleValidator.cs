using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Authorization.Commands.Validator
{
    public class AddRoleValidator : AbstractValidator<AddRoleCommand>
    {

        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;

        public AddRoleValidator(IStringLocalizer<SharedResources> stringLocalizer,
                                                               IAuthorizationService authorizationService)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            ApplyValidationRules();
            ApplyCustomeValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);


        }

        public void ApplyCustomeValidationRules()
        {
            RuleFor(x => x.RoleName)
            .MustAsync(async (Key, CancellationToken) => !await _authorizationService.IsRoleExist(Key))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        }
    }
}
