using Kafedra.Domain.Entities;
using Kafedra.Domain.Identities;
using Kafedra.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Persistence.Contexts
{
    public class KafedraContext : IdentityDbContext
    {

        public KafedraContext(DbContextOptions<KafedraContext> options):base(options) { }


        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<Dissertation> Dissertations { get; set; }
        public DbSet<Faculty> Faculties{ get; set; }
        public DbSet<Qualification> Qualifications{ get; set; }
        public DbSet<SubjectQualification> SubjectQualifications{ get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Syllabus> Syllabuss { get; set; }
        public DbSet<UserDissertation> UserDissertations { get; set; }
        public DbSet<UserSubject> UserSubjects { get; set; }
        public DbSet<Announcement> Announcements{ get; set; }
        public DbSet<Event> Events{ get; set; }
        public DbSet<Slider> Sliders{ get; set; }
        public DbSet<Partners> Partners{ get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<CurriculumSubject> CurriculumSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
            modelBuilder.ApplyConfiguration(new CurriculumConfiuration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new DissertationConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new QualificationConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
