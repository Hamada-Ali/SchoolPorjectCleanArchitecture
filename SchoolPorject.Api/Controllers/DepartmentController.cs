using Microsoft.AspNetCore.Mvc;
using SchoolPorject.Api.Base;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Domain.ApplicantionMetaData;

namespace SchoolPorject.Api.Controllers
{
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromQuery] GetByIdDepartmentQuery query)
        {
            var response = await Mediator.Send(query); // alternative to { Id = id }
            return NewResult(response);
        }

        [HttpGet(Router.DepartmentRouting.GetDepartmentStudentCountById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetDepartmentStudentCountByIdQuery() { DID = id }); // alternative to { Id = id }
            return NewResult(response);
        }

        [HttpGet(Router.DepartmentRouting.GetDepartmentStudentsCount)]
        public async Task<IActionResult> GetDepartmentStudentsCount()
        {
            var response = await Mediator.Send(new GetDepartmentStudentCountQuery()); // alternative to { Id = id }
            return NewResult(response);
        }
    }
}
