using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.IdentityUser.Commands.Models
{
    public class AddUserCommand : IRequest<ResponseInformation<string>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? PhoneNubmer { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
