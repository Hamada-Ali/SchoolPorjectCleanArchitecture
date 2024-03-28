using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Authorization.Commands.Validator
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;

        public DeleteRoleValidator(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            ApplyValidationRules();
            ApplyCustomeValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
        }

        public void ApplyCustomeValidationRules()
        {
            //RuleFor(x => x.Id)
            //.MustAsync(async (Key, CancellationToken) => await _authorizationService.IsRoleExistById(Key))
            //.WithMessage(_stringLocalizer[SharedResourcesKeys.RoleNotExist]);
        }
    }
}
