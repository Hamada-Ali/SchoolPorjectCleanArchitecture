using SchoolProject.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Domain.Entities
{
    public class Subjects : GeneralLocalizableEntity
    {
        public Subjects()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubID { get; set; }
        [StringLength(500)]
        public string? SubjectNameAr { get; set; }
        public string? SubjectNameEn { get; set; }
        public int? Period { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
        [InverseProperty("Subjects")]
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }

    }
}
