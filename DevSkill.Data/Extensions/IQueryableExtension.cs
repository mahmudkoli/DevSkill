using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Data.Extensions
{
    public static class IQueryableExtension
    {
        public static IOrderedQueryable<TEntity> ApplyOrdering<TEntity>(IQueryable<TEntity> query, string sortBy)
        {
            IOrderedQueryable<TEntity> orderedQuery = (IOrderedQueryable<TEntity>)query;
            var orderByList = sortBy.Split(',');

            if (!orderByList.Any()) return orderedQuery;

            var orderBy = orderByList[0];
            var prop = typeof(TEntity).GetProperty(orderBy.Split(' ')[0]);

            if (orderBy.Split(' ')[1] == "asc")
                orderedQuery = orderedQuery.OrderBy(x => prop.Name);
            else
                orderedQuery = orderedQuery.OrderByDescending(x => prop.Name);

            for (int i = 1; i < orderByList.Length; i++)
            {
                orderBy = orderByList[i];
                prop = typeof(TEntity).GetProperty(orderBy.Split(' ')[0]);

                if (orderBy.Split(' ')[1] == "asc")
                    orderedQuery = orderedQuery.ThenBy(x => prop.Name);
                else
                    orderedQuery = orderedQuery.ThenByDescending(x => prop.Name);
            }

            return orderedQuery;
        }
    }
}
