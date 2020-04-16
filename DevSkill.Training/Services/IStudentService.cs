using DevSkill.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Training.Services
{
    public interface IStudentService
    {
        Task<(IList<Student> Items, int Total, int TotalDisplay)> GetAllAsync(
            string searchText, 
            string orderBy, 
            int pageIndex, 
            int pageSize);

        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student entity);
        Task UpdateAsync(Student entity);
        Task DeleteAsync(int id);
    }
}
