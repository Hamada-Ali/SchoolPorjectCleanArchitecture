﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolPorject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Filters;
using SchoolProject.Domain.ApplicantionMetaData;

namespace SchoolPorject.Api.Controllers
{
    //[Route("api/[controller]")] We don't need this we have our custome controller
    //[ApiController]
    [Authorize(Roles = "admin")]
    public class StudentController : AppControllerBase
    {
        [HttpGet(Router.StudentRouting.List)] // custome routing ( ApplicationMetaData folder )
        [Authorize(Roles = "user")]
        [ServiceFilter(typeof(AuthFilter))]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return NewResult(response);
        }

        [HttpGet(Router.StudentRouting.PaginatedList)] // custome routing ( ApplicationMetaData folder )
        public async Task<IActionResult> PaginatedList([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(id)); // alternative to { Id = id }
            return NewResult(response);
        }

        [Authorize(Policy = "CreateStudent")]
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
        {
            var response = await Mediator.Send(command); // alternative to { Id = id }
            return NewResult(response);
        }

        [Authorize(Policy = "EditStudent")]
        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
        {
            var response = await Mediator.Send(command); // alternative to { Id = id }
            return NewResult(response);
        }


        [Authorize(Policy = "DeleteStudent")]
        [HttpDelete(Router.StudentRouting.GetById)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand(id)); // alternative to { Id = id }
            return NewResult(response);
        }
    }
}
