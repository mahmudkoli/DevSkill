using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public interface IStudentService : IDisposable
    {
        Task AddAsync(Student entity);
        Task<IList<Student>> GetAllAsync();
    }
}
