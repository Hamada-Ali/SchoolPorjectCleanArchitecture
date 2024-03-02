using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Bases;
using System.Net;

namespace SchoolPorject.Api.Base
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        private IMediator _mediator;

        // mediator handles the requets between controllers and services
        //public AppControllerBase(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); // alternative way to use _mediator instad of the dependency injection way so we can inherit it to another class


        public ObjectResult NewResult<T>(ResponseInformation<T> response)
        {
            switch (response.StatusCode) // note : this object results are inherited from controllerBase ( built in )
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                case HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);
            }
        }
    }
}
