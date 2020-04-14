using DevSkill.Training.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Training.Services
{
    public class StudentRegistrationService : IStudentRegistrationService
    {
        private ICourseUnitOfWork _courseUnitOfWork;

        public StudentRegistrationService(ICourseUnitOfWork courseUnitOfWork)
        {
            _courseUnitOfWork = courseUnitOfWork;
        }
    }
}
