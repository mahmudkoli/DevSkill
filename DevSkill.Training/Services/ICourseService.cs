using DevSkill.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Training.Services
{
    public interface ICourseService
    {
        Task<(IList<Course> Items, int Total, int TotalDisplay)> GetAllAsync(
            string searchText,
            string orderBy,
            int pageIndex,
            int pageSize);

        Task<Course> GetByIdAsync(int id);
        Task AddAsync(Course entity);
        Task UpdateAsync(Course entity);
        Task DeleteAsync(int id);
    }
}
