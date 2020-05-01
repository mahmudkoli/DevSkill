using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public interface IStudentRepository : IRepository<Student, int, CourseDbContext>
    {
        
    }
}
