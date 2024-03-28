using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Dto;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class GetRoleById : IRequest<ResponseInformation<GetRolesListDto>>
    {
        public int Id { get; set; }

        public GetRoleById(int id)
        {
            Id = id;
        }
    }
}
