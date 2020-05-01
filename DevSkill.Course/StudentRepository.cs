using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public class StudentRepository : Repository<Student, int, CourseDbContext>, IStudentRepository
    {
        private readonly CourseDbContext dbContext;

        public StudentRepository(CourseDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
