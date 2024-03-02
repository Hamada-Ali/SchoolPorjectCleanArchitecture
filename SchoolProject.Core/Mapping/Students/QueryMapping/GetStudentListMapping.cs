using SchoolProject.Core.Features.Students.Queries.Dto;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Students // not the actual namespace of the file
{

    // partial class should be in the same namespace
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, StudentDto>()
            .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
             .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.Department.DNameAr, src.Department.DNameEn)));
        }
    }
}
