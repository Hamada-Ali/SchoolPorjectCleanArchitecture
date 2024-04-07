using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Query.Models
{
    public class ConfirmEmailQuery : IRequest<ResponseInformation<string>>
    {
        public int UserId { get; set; }
        public string Code { get; set; }
    }
}
