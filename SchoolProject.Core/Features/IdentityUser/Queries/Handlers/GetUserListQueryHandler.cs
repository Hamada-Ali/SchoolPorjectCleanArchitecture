using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.IdentityUser.Queries.Dto;
using SchoolProject.Core.Features.IdentityUser.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Features.IdentityUser.Queries.Handlers
{
    public class GetUserListQueryHandler : ResponseHandler,
                    IRequestHandler<GetUserPaginatedListQuery, PaginatedResult<GetUserListResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly UserManager<User> _userManager;

        public GetUserListQueryHandler(IMapper mapper, IStringLocalizer<SharedResources> localizer, UserManager<User> userManager) : base(localizer)
        {
            _localizer = localizer;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<PaginatedResult<GetUserListResponse>> Handle(GetUserPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();

            var paginatedList = await _mapper.ProjectTo<GetUserListResponse>(users)
                                            .ToPaginatedListAsync(request.PageNubmer, request.PageSize);

            return paginatedList;
        }
    }
}
