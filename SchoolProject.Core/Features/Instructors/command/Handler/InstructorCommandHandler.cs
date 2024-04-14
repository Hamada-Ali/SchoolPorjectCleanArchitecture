using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Entities;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Instructors.command.Handler
{
    public class InstructorCommandHandler : ResponseHandler,
                                            IRequestHandler<AddInstructorCommand, ResponseInformation<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;

        public InstructorCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, IInstructorService instructorService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _instructorService = instructorService;
        }


        public async Task<ResponseInformation<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Instructor>(request);
            var result = await _instructorService.AddInstructorAsync(instructor, request.Image);

            switch (result)
            {
                case "NoImage": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.NoImage]);
                case " FailedToUpload": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.OperationFailed]);
            }

            return Success("");
        }
    }
}
