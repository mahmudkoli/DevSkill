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
    public class StudentRegistrationRepository : Repository<StudentRegistration, int, TrainingContext>, IStudentRegistrationRepository
    {
        public StudentRegistrationRepository(TrainingContext dbContext)
            : base(dbContext)
        {

        }
    }
}
