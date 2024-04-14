using SchoolProject.Core.Features.Instructors.command.Models;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Instructors
{
    public partial class InstructorProfile
    {
        public void AddInstructorMapping()
        {
            CreateMap<AddInstructorCommand, Instructor>()
            .ForMember(dto => dto.Image, opt => opt.Ignore())
            .ForMember(dto => dto.ENameAr, options => options.MapFrom(entity => entity.NameAr))
            .ForMember(dto => dto.ENameEn, options => options.MapFrom(entity => entity.NameEn));
        }
    }
}
