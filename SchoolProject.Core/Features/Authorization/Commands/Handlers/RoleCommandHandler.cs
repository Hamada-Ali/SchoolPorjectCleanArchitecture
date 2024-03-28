using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Authorization.Commands.Handlers
{
    public class RoleCommandHandler : ResponseHandler,
        IRequestHandler<AddRoleCommand, ResponseInformation<string>>,
        IRequestHandler<EditRoleCommand, ResponseInformation<string>>,
        IRequestHandler<DeleteRoleCommand, ResponseInformation<string>>,
        IRequestHandler<UpdateUserRolesCommand, ResponseInformation<string>>
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

        public async Task<ResponseInformation<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.EditRoleAsync(request);

            if (result == "notfound")
            {
                return NotFound<string>();
            }
            else if (result == "Success")
            {
                return Success<string>(_stringLocalizer[SharedResourcesKeys.updated]);
            }
            else
            {
                return BadRequest<string>(result);

            }
        }

        public async Task<ResponseInformation<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.DeleteRoleAsync(request.Id);

            if (result == "NotFound")
            {
                return NotFound<string>();
            }
            else if (result == "Used")
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.RoleIsUsed]);
            }
            else if (result == "Success")
            {
                return Success<string>(_stringLocalizer[SharedResourcesKeys.success]);

            }
            else
            {
                return BadRequest<string>("");
            }
        }

        public async Task<ResponseInformation<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserRoles(request);
            switch (result)
            {
                case "NotFound": return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
                case "FailedToRemoveOldRoles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToRemoveOldRoles]);
                case "FailedToAddNewRoles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToAddNewRoles]);
                case "FailedToAddUserRoles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUpdateUserRoles]);
            }
            return Success<string>(_stringLocalizer[SharedResourcesKeys.success]);
        }
    }
}
