using DevSkill.Data;
using DevSkill.Training.Context;
using DevSkill.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Training.Repositories
{
    public interface IStudentRegistrationRepository : IRepository<StudentRegistration, int, TrainingContext>
    {
        
    }
}
