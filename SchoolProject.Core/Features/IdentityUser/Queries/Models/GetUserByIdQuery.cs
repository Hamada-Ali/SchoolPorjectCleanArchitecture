using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.IdentityUser.Queries.Dto;

namespace SchoolProject.Core.Features.IdentityUser.Queries.Models
{
    public class GetUserByIdQuery : IRequest<ResponseInformation<GetUserByIdResponse>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
