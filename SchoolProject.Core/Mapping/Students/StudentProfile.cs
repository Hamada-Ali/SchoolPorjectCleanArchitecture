using AutoMapper;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping(); // using the functions only
            GetStudentByIdMapping();
            AddStudentCommandMapping();
            EditStudentCommandMapping();
            GetStudnetPagination();
        }
    }
}
