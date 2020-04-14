using DevSkill.Data;
using DevSkill.Training.Context;
using DevSkill.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Training.UnitOfWork
{
    public class CourseUnitOfWork : UnitOfWork<TrainingContext>, ICourseUnitOfWork
    {
        public IStudentRepository StudentRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public IStudentRegistrationRepository StudentRegistrationRepository { get; set; }

        public CourseUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            StudentRepository = new StudentRepository(_dbContext);
            CourseRepository = new CourseRepository(_dbContext);
            StudentRegistrationRepository = new StudentRegistrationRepository(_dbContext);
        }
    }
}
