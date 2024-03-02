using SchoolProject.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Domain.Entities
{
    public class Instructor : GeneralLocalizableEntity
    {

        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        public int InsId { get; set; }
        public string? ENameAr { get; set; }
        public string? ENameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public string? Image { get; set; }
        public int DID { get; set; }
        [ForeignKey(nameof(DID))]
        [InverseProperty("Instructors")]
        public Department? department { get; set; }
        [InverseProperty("Instructor")]
        public Department? departmentManager { get; set; }
        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty("Instructors")]
        public Instructor? supervisor { get; set; }
        [InverseProperty("supervisor")]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [InverseProperty("instructor")]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
    }
}
