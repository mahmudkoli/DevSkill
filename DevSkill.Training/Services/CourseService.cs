using DevSkill.Training.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Training.Services
{
    public class CourseService : ICourseService
    {
        private ICourseUnitOfWork _courseUnitOfWork;

        public CourseService(ICourseUnitOfWork courseUnitOfWork)
        {
            _courseUnitOfWork = courseUnitOfWork;
        }
    }
}
