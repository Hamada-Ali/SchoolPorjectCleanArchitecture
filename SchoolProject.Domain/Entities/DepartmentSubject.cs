using SchoolProject.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Domain.Entities
{
    public class DepartmentSubject : GeneralLocalizableEntity
    {
        //[Key]
        //public int DeptSubID { get; set; }
        [Key]
        public int DID { get; set; }
        [Key]
        public int SubID { get; set; }
        [ForeignKey("DID")]
        [InverseProperty("DepartmentSubjects")]
        public virtual Department Departments { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty("DepartmentSubjects")]
        public virtual Subjects Subjects { get; set; }
    }
}
