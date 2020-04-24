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
    public class CourseUnitOfWork : DevSkill.Data.UnitOfWork, ICourseUnitOfWork
    {
        public IStudentRepository StudentRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public IStudentRegistrationRepository StudentRegistrationRepository { get; set; }

        public CourseUnitOfWork(TrainingContext dbContext,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IStudentRegistrationRepository studentRegistrationRepository) : base(dbContext)
        {
            StudentRepository = studentRepository;
            CourseRepository = courseRepository;
            StudentRegistrationRepository = studentRegistrationRepository;
        }
    }
}
