using MediatR;
using SchoolProject.Core.Features.IdentityUser.Queries.Dto;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.IdentityUser.Queries.Models
{
    public class GetUserPaginatedListQuery : IRequest<PaginatedResult<GetUserListResponse>>
    {
        public int PageNubmer { get; set; }
        public int PageSize { get; set; }
    }
}
