using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public class GradeRepository : Repository<Grade, int, CourseDbContext>, IGradeRepository
    {
        private readonly CourseDbContext dbContext;

        public GradeRepository(CourseDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
