using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Entities;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, ResponseInformation<string>>,
        IRequestHandler<EditStudentCommand, ResponseInformation<string>>,
        IRequestHandler<DeleteStudentCommand, ResponseInformation<string>>

    {
        private readonly IStudentService _service;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public StudentCommandHandler(IStudentService service, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _service = service;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<ResponseInformation<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentmapper = _mapper.Map<Student>(request);

            var result = await _service.AddAsync(studentmapper);

            if (result == "Success") return Created<string>(_stringLocalizer[SharedResourcesKeys.success]);

            return BadRequest<string>();


        }

        public async Task<ResponseInformation<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // check if the if of the student is exist or not
            var studnet = _service.GetStudentByIdAsync(request.Id);

            if (studnet == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var studentMapper = _mapper.Map<Student>(request);

            var result = await _service.EditAsync(studentMapper);

            if (result == "Success") return Success($"Edit Success | ID = {studentMapper.StudId}");

            return BadRequest<string>();
        }

        public async Task<ResponseInformation<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _service.GetStudentByIdAsync(request.Id);

            if (student == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var result = await _service.DeleteAsync(student);

            if (result == "Success") return Deleted<string>($"{_stringLocalizer[SharedResourcesKeys.deleted]} | ID = {request.Id}");

            return BadRequest<string>();
        }
    }
}
