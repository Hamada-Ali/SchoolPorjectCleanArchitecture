using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.IdentityUser.Commands.Models
{
    public class UpdateUserCommand : IRequest<ResponseInformation<string>>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? PhoneNubmer { get; set; }
    }
}
