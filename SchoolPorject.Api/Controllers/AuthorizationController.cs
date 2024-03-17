using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolPorject.Api.Base;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Domain.ApplicantionMetaData;

namespace SchoolPorject.Api.Controllers
{
    [Authorize]
    public class AuthorizationController : AppControllerBase
    {
        [HttpPost(Router.Authorization.Create)]
        public async Task<IActionResult> Create([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command); // alternative to { Id = id }
            return NewResult(response);
        }
    }
}
