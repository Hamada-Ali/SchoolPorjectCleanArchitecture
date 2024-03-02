using SchoolProject.Core.Features.Students.Queries.Dto;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, StudentDto>()
                    .ForMember(dto => dto.Name, options => options.MapFrom(entity => entity.Localize(entity.NameAr, entity.NameEn)))
                    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.Department.DNameAr, src.Department.DNameEn)));

        }
    }
}
