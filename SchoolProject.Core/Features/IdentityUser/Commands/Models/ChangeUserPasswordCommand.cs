using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.IdentityUser.Commands.Models
{
    public class ChangeUserPasswordCommand : IRequest<ResponseInformation<string>>
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
