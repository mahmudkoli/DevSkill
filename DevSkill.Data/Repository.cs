using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity) => _dbSet.Add(entity);

        public virtual void Edit(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual IList<TResult> Get<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).Select(selector).ToList();
            else
                return query.Select(selector).ToList();
        }

        public virtual (IList<TResult> Items, int Total, int TotalDisplay) Get<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            int pageIndex = 1, int pageSize = 10,
                            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();
            int total = query.Count();
            int totalDisplay = total;

            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
            {
                query = query.Where(predicate);
                totalDisplay = query.Count();
            }

            if (orderBy != null)
                query = orderBy(query);

            return (query.Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(selector).ToList(), total, totalDisplay);
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count();
        }

        public virtual void Remove(int id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Remove(Expression<Func<TEntity, bool>> filter) => _dbSet.RemoveRange(_dbSet.Where(filter));
    }
}
