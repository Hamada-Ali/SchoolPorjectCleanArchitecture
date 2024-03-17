using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Domain.Helpers;

namespace SchoolProject.Core.Features.Authentication.Command.Model
{
    public class RefreshTokenCommand : IRequest<ResponseInformation<JwtAuthDto>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
