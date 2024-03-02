using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrustructure.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Department> departments { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<DepartmentSubject> departmentSubjects { get; set; }
        public DbSet<Subjects> subjects { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }

        // using fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.HasDefaultSchema("school");

            //modelBuilder.Entity<Student>()
            //    .HasKey(x => x.StudId); 

            modelBuilder.Entity<DepartmentSubject>()
                .HasKey(x => new { x.SubID, x.DID }); // composite primary key

            modelBuilder.Entity<Ins_Subject>()
                .HasKey(x => new { x.SubId, x.InsId });

            modelBuilder.Entity<StudentSubject>()
             .HasKey(x => new { x.StudID, x.SubID });

            modelBuilder.Entity<Instructor>()
                .HasOne(x => x.supervisor)
                .WithMany(x => x.Instructors)
                .HasForeignKey(x => x.SupervisorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Department>()
                .HasOne(x => x.Instructor)
                .WithOne(x => x.departmentManager)
                .HasForeignKey<Department>(x => x.InsManager)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
