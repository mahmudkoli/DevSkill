using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext) => _dbContext = dbContext;

        public void SaveChanges() => _dbContext?.SaveChanges();
        public Task SaveChangesAsync() => _dbContext?.SaveChangesAsync();

        public void Dispose() => _dbContext?.Dispose();
    }
}
