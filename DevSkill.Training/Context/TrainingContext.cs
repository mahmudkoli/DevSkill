using DevSkill.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Training.Context
{
    public class TrainingContext : DbContext, ITrainingContext
    {

        private string _connectionString;
        private string _migrationAssemblyName;

        public TrainingContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentRegistration> StudentRegistrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentRegistration>(stdReg =>
            {
                stdReg.HasKey(ur => new { ur.StudentId, ur.CourseId });

                stdReg.HasOne(sc => sc.Student)
                    .WithMany(s => s.StudentRegistrations)
                    .HasForeignKey(sc => sc.StudentId)
                    .IsRequired();

                stdReg.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentRegistrations)
                    .HasForeignKey(sc => sc.CourseId)
                    .IsRequired();
            });

            base.OnModelCreating(builder);
        }
    }
}
