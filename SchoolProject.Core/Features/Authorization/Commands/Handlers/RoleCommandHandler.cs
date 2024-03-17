using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Authorization.Commands.Handlers
{
    public class RoleCommandHandler : ResponseHandler,
        IRequestHandler<AddRoleCommand, ResponseInformation<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        // private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthorizationService _authorizationService;

        public RoleCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
        }

        public async Task<ResponseInformation<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.AddRoleAsync(request.RoleName);

            if (result == "Success")
            {
                return Success(result);
            }

            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.OperationFailed]);
        }
    }
}
