namespace SchoolProject.Core.Features.Students.Queries.Dto
{
    public class StudentPaginatedList
    {
        public StudentPaginatedList(int studId, string? name, string? address, string? departmentName)
        {
            StudId = studId;
            Name = name;
            Address = address;
            DepartmentName = departmentName;
        }

        public int StudId { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? DepartmentName { get; set; }


    }
}
