using SchoolProject.Core.Features.Department.Queries.Dto;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Departments

{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetByIdDepartmentResponse>()
                 .ForMember(dto => dto.Name, options => options.MapFrom(entity => entity.Localize(entity.DNameAr, entity.DNameEn)))
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                    .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.Localize(src.Instructor.ENameAr, src.Instructor.ENameEn)))
                    .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                    //.ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students))
                    .ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.Instructors));

            CreateMap<DepartmentSubject, SubjectResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subjects.Localize(src.Subjects.SubjectNameAr, src.Subjects.SubjectNameEn)));

            //CreateMap<Student, StudentResponse>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudId))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

            CreateMap<Instructor, InstructorResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.ENameAr, src.ENameEn)));
        }
    }
}