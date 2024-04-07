using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Infrustructure.Domain
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    // we converting all ids in User Table to int instead of GUID ex. RoleId, userId
    {
        private readonly IEncryptionProvider _encryptionProvider;
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // this is the key we can decrypt the column with
            _encryptionProvider = new GenerateEncryptionProvider("68d09eda6a294cf7aeb945e56f5c0b8568d09eda6a294cf7aeb945e56f5c0b85");
        }

        public DbSet<User> User { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<DepartmentSubject> departmentSubjects { get; set; }
        public DbSet<Subjects> subjects { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }

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

            modelBuilder.UseEncryption(_encryptionProvider);

            base.OnModelCreating(modelBuilder);
        }
    }
}
