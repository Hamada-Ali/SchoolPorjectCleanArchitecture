using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.IdentityUser.Commands.Models
{
    public class DeleteUserCommand : IRequest<ResponseInformation<string>>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
