using SchoolProject.Core.Features.Department.Queries.Dto;
using SchoolProject.Domain.Entities.Views;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudentCountDto()
        {
            CreateMap<ViewDepartment, GetDepartmentStudentCountDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(entity => entity.Localize(entity.DNameAr, entity.DNameEn)))
                .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.StudentCount));
        }
    }
}
