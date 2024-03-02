using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Department.Queries.Dto
{
    public class GetByIdDepartmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public PaginatedResult<StudentResponse>? StudentList { get; set; }
        public List<SubjectResponse>? SubjectList { get; set; }
        public List<InstructorResponse>? InstructorList { get; set; }
    }

    public class StudentResponse
    {
        public StudentResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { set; get; }
        public string Name { get; set; }



    }

    public class SubjectResponse
    {
        public int Id { set; get; }
        public string Name { get; set; }

    }

    public class InstructorResponse
    {
        public int Id { set; get; }
        public string Name { get; set; }
    }
}
