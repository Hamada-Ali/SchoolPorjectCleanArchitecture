using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Domain.Helpers;

namespace SchoolProject.Core.Features.Authentication.Command.Model
{
    public class SignInCommand : IRequest<ResponseInformation<JwtAuthDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
