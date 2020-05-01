using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public interface ISubjectRepository : IRepository<Subject, int, CourseDbContext>
    {
        
    }
}
