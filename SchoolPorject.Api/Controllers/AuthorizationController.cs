using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolPorject.Api.Base;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Domain.ApplicantionMetaData;

namespace SchoolPorject.Api.Controllers
{
    [Authorize(Roles = "admin")]
    public class AuthorizationController : AppControllerBase
    {
        [HttpPost(Router.Authorization.CreateRole)]
        public async Task<IActionResult> Create([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command); // alternative to { Id = id }
            return NewResult(response);
        }
        [HttpPost(Router.Authorization.EditRole)]
        public async Task<IActionResult> Edit([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command); // alternative to { Id = id }
            return NewResult(response);

        }

        [HttpDelete(Router.Authorization.DeleteRole)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteRoleCommand(id)); // alternative to { Id = id }
            return NewResult(response);
        }

        [HttpGet(Router.Authorization.GetRolesList)]
        public async Task<IActionResult> GetList()
        {
            var response = await Mediator.Send(new GetRolesListQuery());
            return Ok(response);
        }

        [HttpGet(Router.Authorization.GetRoleById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetRoleById(id));
            return Ok(response);
        }

        [HttpGet(Router.Authorization.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] int userId)
        {
            var response = await Mediator.Send(new ManageUserRolesQuery(userId));
            return Ok(response);
        }

        [HttpPut(Router.Authorization.UpdateUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromBody] UpdateUserRolesCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet(Router.Authorization.ManageUserClaims)]
        public async Task<IActionResult> ManageUserClaims([FromRoute] int userId)
        {
            var response = await Mediator.Send(new ManageUserClaimsQuery(userId));
            return Ok(response);
        }

        [HttpPost(Router.Authorization.UpdateUserClaims)]
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

    }
}
