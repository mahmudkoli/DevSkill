using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Edit(TEntity entityToUpdate);
        IList<TResult> Get<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            bool disableTracking = true);
        (IList<TResult> Items, int Total, int TotalDisplay) Get<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            int pageIndex = 1, int pageSize = 10,
                            bool disableTracking = true);
        TEntity GetById(int id);
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
        void Remove(Expression<Func<TEntity, bool>> filter);
        void Remove(int id);
        void Remove(TEntity entityToDelete);
    }
}
