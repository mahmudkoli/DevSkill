﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Data
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : DbContext
    {
        protected readonly TEntity _dbContext;

        public UnitOfWork(string connectionString, string migrationAssemblyName)
            => _dbContext = (TEntity)Activator.CreateInstance(typeof(TEntity), connectionString, migrationAssemblyName);

        public void Dispose() => _dbContext?.Dispose();

        public Task SaveChangesAsync() => _dbContext?.SaveChangesAsync();
    }
}
