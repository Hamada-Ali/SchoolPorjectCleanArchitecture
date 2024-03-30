using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Dto;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
    public class ClaimsQueryHandler : ResponseHandler,
                                        IRequestHandler<ManageUserClaimsQuery, ResponseInformation<ManageUserClaimsResults>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<User> _userManager;

        public ClaimsQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService,
                                                    UserManager<User> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }

        public async Task<ResponseInformation<ManageUserClaimsResults>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null) { return NotFound<ManageUserClaimsResults>(_stringLocalizer[SharedResourcesKeys.NotFound]); }

            var result = await _authorizationService.ManageUserClaimsData(user);

            return Success(result);
        }
    }
}
