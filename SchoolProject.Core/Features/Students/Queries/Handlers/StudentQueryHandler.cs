using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Dto;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Entities;
using SchoolProject.Services.Interface;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
                                        IRequestHandler<GetStudentListQuery, ResponseInformation<List<StudentDto>>>,
                                        IRequestHandler<GetStudentByIdQuery, ResponseInformation<StudentDto>>,
                                        IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<StudentPaginatedList>>
    {
        private readonly IStudentService _service;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public StudentQueryHandler(IStudentService service, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _service = service;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        public async Task<ResponseInformation<List<StudentDto>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            // main entity of student
            var studentList = await _service.GetStudentsListAsync();

            // mapped Student to StudentDto
            var mappedStudentList = _mapper.Map<List<StudentDto>>(studentList);

            var result = Success(mappedStudentList); // we get success function from implemnting response handler

            result.Meta = new { Count = mappedStudentList.Count };

            return result;
        }

        public async Task<ResponseInformation<StudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _service.GetStudentByIdAsync(request.Id);

            if (student == null)
            {
                return NotFound<StudentDto>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }

            var result = _mapper.Map<StudentDto>(student);

            return Success(result);
        }

        public async Task<PaginatedResult<StudentPaginatedList>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, StudentPaginatedList>> expression = e => new StudentPaginatedList(e.StudId, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.Localize(e.Department.DNameAr, e.Department.DNameEn));

            // var querable = _service.GetStudentsQueryable();

            var FilteredQuery = _service.FilterStudentPaginatedQueryable(request.OrderBy, request.Search);

            var paginatedList = await FilteredQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            paginatedList.Meta = new { Count = paginatedList.Data.Count };

            return paginatedList;
        }


    }
}
