using DevSkill.Training.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Training.Services
{
    public class StudentService : IStudentService
    {
        private ICourseUnitOfWork _courseUnitOfWork;

        public StudentService(ICourseUnitOfWork courseUnitOfWork)
        {
            _courseUnitOfWork = courseUnitOfWork;
        }
    }
}
