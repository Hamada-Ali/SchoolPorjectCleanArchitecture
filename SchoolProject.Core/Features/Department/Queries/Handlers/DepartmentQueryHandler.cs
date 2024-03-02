using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Dto;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Entities;
using SchoolProject.Services.Interface;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetByIdDepartmentQuery, ResponseInformation<GetByIdDepartmentResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                                IDepartmentService departmentService,
                                                IMapper mapper,
                                                IStudentService studentService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _departmentService = departmentService;
            _studentService = studentService;
        }

        public async Task<ResponseInformation<GetByIdDepartmentResponse>> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
        {
            // we need service 
            var dept = await _departmentService.GetDepartmentById(request.Id);

            if (dept == null)
            {
                return NotFound<GetByIdDepartmentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }

            var mapped_dept = _mapper.Map<GetByIdDepartmentResponse>(dept);

            // pagination for student in department ( student list )
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudId, e.Localize(e.NameAr, e.NameEn));

            var studnetQuerable = _studentService.GetStudentsByDepartmentIdQuerable(request.Id);

            var paginatedList = await studnetQuerable.Select(expression).ToPaginatedListAsync(request.StudentPageNubmer, request.StudnetPageSize);

            mapped_dept.StudentList = paginatedList;

            return Success(mapped_dept);
        }
    }
}
