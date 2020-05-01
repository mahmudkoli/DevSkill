using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public interface ISubjectService : IDisposable
    {
        Task AddAsync(Subject entity);
        Task<IList<Subject>> GetAllAsync();
    }
}
