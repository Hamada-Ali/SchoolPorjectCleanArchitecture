using SchoolProject.Core.Features.Department.Queries.Dto;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Domain.Entities.Procedures;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudentCountByIdMapping()
        {
            CreateMap<GetDepartmentStudentCountByIdQuery, DepartmentStudentCountProcParams>();

            CreateMap<DepartmentStudentCountProc, GetDepartmentStudentCountByIdDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(entity => entity.Localize(entity.DNameAr, entity.DNameEn)))
                .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.StudentCount));

        }
    }
}
