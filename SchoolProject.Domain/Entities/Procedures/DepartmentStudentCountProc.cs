using SchoolProject.Domain.Common;

namespace SchoolProject.Domain.Entities.Procedures
{
    public class DepartmentStudentCountProc : GeneralLocalizableEntity
    {
        public int DID { get; set; }
        public string? DNameAr { get; set; }
        public string? DNameEn { get; set; }
        public int StudentCount { get; set; }
    }
    public class DepartmentStudentCountProcParams
    {
        public int DID { get; set; } = 0;


    }
}
