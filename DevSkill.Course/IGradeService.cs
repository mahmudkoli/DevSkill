using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public interface IGradeService : IDisposable
    {
        Task AddAsync(Grade entity);
        Task<IList<Grade>> GetAllAsync();
        Task<IList<object>> GetAllStudentForSelectAsync();
        Task<IList<object>> GetAllSubjectForSelectAsync();
    }
}
