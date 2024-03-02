using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand, Student>()
            .ForMember(dto => dto.DID, options => options.MapFrom(entity => entity.DepartmentId))
            .ForMember(dto => dto.NameAr, options => options.MapFrom(entity => entity.NameAr))
            .ForMember(dto => dto.NameEn, options => options.MapFrom(entity => entity.NameEn));
        }
    }
}
