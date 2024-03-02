using SchoolProject.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Domain.Entities
{
    public class StudentSubject : GeneralLocalizableEntity
    {
        //[Key]
        //public int StudSubID { get; set; }
        [Key]
        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }

        public decimal? Grade { get; set; }

        [ForeignKey("StudID")]
        [InverseProperty("StudentSubjects")]
        public virtual Student? Student { get; set; }
        [ForeignKey("SubID")]
        [InverseProperty("StudentsSubjects")]
        public virtual Subjects? Subject { get; set; }
    }
}
