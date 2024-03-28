using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Dto;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Dto;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
    public class RoleQueryHandler : ResponseHandler,
        IRequestHandler<GetRolesListQuery, ResponseInformation<List<GetRolesListDto>>>,
        IRequestHandler<GetRoleById, ResponseInformation<GetRolesListDto>>,
        IRequestHandler<ManageUserRolesQuery, ResponseInformation<ManageUserRolesDto>>

    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public RoleQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
            IAuthorizationService authorizationService, IMapper mapper, UserManager<User> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ResponseInformation<List<GetRolesListDto>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRolesList();

            var result = _mapper.Map<List<GetRolesListDto>>(roles);

            return Success(result);
        }

        public async Task<ResponseInformation<GetRolesListDto>> Handle(GetRoleById request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleById(request.Id);

            if (role == null)
            {
                return NotFound<GetRolesListDto>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }

            var result = _mapper.Map<GetRolesListDto>(role);

            return Success(result);
        }

        public async Task<ResponseInformation<ManageUserRolesDto>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
            {
                return NotFound<ManageUserRolesDto>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }

            var result = await _authorizationService.GetManageUserRolesData(user);

            return Success(result);
        }
    }
}
