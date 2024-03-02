using SchoolProject.Core.Features.Students.Queries.Dto;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudnetPagination()
        {
            CreateMap<Student, StudentPaginatedList>()
                .ForMember(dto => dto.Name, options => options.MapFrom(entity => entity.Localize(entity.NameAr, entity.NameEn)))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.Department.DNameAr, src.Department.DNameEn)))
                .ForMember(dest => dest.StudId, opt => opt.MapFrom(src => src.StudId))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        }


        public int StudId { get; set; }

        public string? Address { get; set; }


    }
}

