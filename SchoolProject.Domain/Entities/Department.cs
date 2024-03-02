using SchoolProject.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Domain.Entities
{
    public partial class Department : GeneralLocalizableEntity
    {
        public Department()
        {

            // initialize HashSet to prevent Dupliation of data ( unlike List )
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        [StringLength(500)]
        public string DNameAr { get; set; }
        [StringLength(500)]
        public string DNameEn { get; set; }

        public int InsManager { get; set; }

        [InverseProperty(nameof(Student.Department))]
        public virtual ICollection<Student> Students { get; set; }
        [InverseProperty("Departments")]
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
        [InverseProperty("department")]
        public virtual ICollection<Instructor> Instructors { get; set; }
        [ForeignKey(nameof(InsManager))]
        [InverseProperty("departmentManager")]
        public virtual Instructor Instructor { get; set; }
    }
}
