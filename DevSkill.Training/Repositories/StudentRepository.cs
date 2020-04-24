using DevSkill.Data;
using DevSkill.Training.Context;
using DevSkill.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Training.Repositories
{
    public class StudentRepository : Repository<Student, int, TrainingContext>, IStudentRepository
    {
        public StudentRepository(TrainingContext dbContext)
            : base(dbContext)
        {

        }
    }
}
