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
    public interface ICourseUnitOfWork : IUnitOfWork<TrainingContext>
    {
        IStudentRepository StudentRepository { get; set; }
        ICourseRepository CourseRepository { get; set; }
        IStudentRegistrationRepository StudentRegistrationRepository { get; set; }
    }
}
