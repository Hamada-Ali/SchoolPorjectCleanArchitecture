using Microsoft.AspNetCore.Mvc;
using SchoolPorject.Api.Base;
using SchoolProject.Core.Features.Authentication.Command.Model;
using SchoolProject.Core.Features.Authentication.Query.Models;
using SchoolProject.Domain.ApplicantionMetaData;

namespace SchoolPorject.Api.Controllers
{


    public class AuthenticationController : AppControllerBase
    {
        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand command)
        {
            var response = await Mediator.Send(command); // alternative to { Id = id }
            return NewResult(response);
        }

        [HttpPost(Router.Authentication.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
        {
            var response = await Mediator.Send(command); // alternative to { Id = id }
            return NewResult(response);
        }

        [HttpGet(Router.Authentication.ValidateToken)]
        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserQuery query)
        {
            var response = await Mediator.Send(query); // alternative to { Id = id }
            return NewResult(response);
        }

        [HttpGet(Router.Authentication.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
        {
            var response = await Mediator.Send(query); // alternative to { Id = id }
            return NewResult(response);
        }

        [HttpPost(Router.Authentication.SendResetPassword)]
        public async Task<IActionResult> SendResetPassword([FromQuery] ResetPasswordCommand command)
        {
            var response = await Mediator.Send(command); // alternative to { Id = id }
            return NewResult(response);
        }

        [HttpGet(Router.Authentication.CheckResetPasswordConfirmation)]
        public async Task<IActionResult> CheckResetPasswordConfirmation([FromQuery] ResetPasswordQuery command)
        {
            var response = await Mediator.Send(command); // alternative to { Id = id }
            return NewResult(response);
        }

        [HttpPost(Router.Authentication.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordWithConfirmCommand command)
        {
            var response = await Mediator.Send(command); // alternative to { Id = id }
            return NewResult(response);
        }
    }
}
