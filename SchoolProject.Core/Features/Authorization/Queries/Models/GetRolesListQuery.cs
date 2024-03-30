
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Dto;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class GetRolesListQuery : IRequest<ResponseInformation<List<GetRolesListDto>>>
    {

    }
}
