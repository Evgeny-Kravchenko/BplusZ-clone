using Raven.Client.Documents;
using System.Linq;

namespace Synnotech_BplusZ.WebApi.Extensions
{
    public static class QuerableOrderByExtension
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, string sortField, bool isAscendingSortOrder)
        {
            if (isAscendingSortOrder)
            {
                query = query.OrderBy(sortField);
            }
            else
            {
                query = query.OrderByDescending(sortField);
            }

            return query;
        }
    }
}
