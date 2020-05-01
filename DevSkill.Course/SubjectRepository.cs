using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public class SubjectRepository : Repository<Subject, int, CourseDbContext>, ISubjectRepository
    {
        private readonly CourseDbContext dbContext;

        public SubjectRepository(CourseDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
