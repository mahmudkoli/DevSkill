using DevSkill.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Training.Services
{
    public interface IStudentRegistrationService : IDisposable
    {
        Task<(IList<StudentRegistration> Items, int Total, int TotalDisplay)> GetAllAsync(
            string searchText,
            string orderBy,
            int pageIndex,
            int pageSize);

        Task<StudentRegistration> GetByIdAsync(int id); 
        Task<IList<object>> GetStudentsForSelectAsync();
        Task<IList<object>> GetCoursesForSelectAsync();
        Task AddAsync(StudentRegistration entity);
        Task UpdateAsync(StudentRegistration entity);
        Task DeleteAsync(int id);
    }
}
