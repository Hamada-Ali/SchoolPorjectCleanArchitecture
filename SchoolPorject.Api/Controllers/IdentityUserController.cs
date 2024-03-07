using Microsoft.AspNetCore.Mvc;
using SchoolPorject.Api.Base;
using SchoolProject.Core.Features.IdentityUser.Commands.Models;
using SchoolProject.Core.Features.IdentityUser.Queries.Models;
using SchoolProject.Domain.ApplicantionMetaData;

namespace SchoolPorject.Api.Controllers
{
    [ApiController]
    public class IdentityUserController : AppControllerBase
    {
        [HttpPost(Router.IdentityUser.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command); // alternative to { Id = id }
            return NewResult(response);
        }

        [HttpPost(Router.IdentityUser.Paginated)]
        public async Task<IActionResult> GetPaginatedList([FromQuery] GetUserPaginatedListQuery query)
        {
            var response = await Mediator.Send(query); // alternative to { Id = id }
            return Ok(response); // we use Ok here because GetUserPaginatedListQuery don't return responseinformation
        }

        [HttpGet(Router.IdentityUser.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }

        [HttpPut(Router.IdentityUser.Update)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpPut(Router.IdentityUser.UpdatePassowrd)]
        public async Task<IActionResult> UpdatePassowrd([FromBody] ChangeUserPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.IdentityUser.GetById)]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(response);
        }

    }
}
