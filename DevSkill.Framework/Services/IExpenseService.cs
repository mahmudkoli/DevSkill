using DevSkill.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Framework.Services
{
    public interface IExpenseService : IDisposable
    {
        Task<(IList<Entities.Expense> Items, int Total, int TotalDisplay)> GetAllAsync(
            string searchText, 
            string orderBy, 
            int pageIndex, 
            int pageSize);

        Task<Entities.Expense> GetByIdAsync(int id);
        Task AddAsync(Entities.Expense entity);
        Task UpdateAsync(Entities.Expense entity);
        Task<Expense> DeleteAsync(int id);
    }
}
