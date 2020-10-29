using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using System.Linq;

namespace Synnotech_BplusZ.WebApi.Extensions
{
    public static class QueryableOrderByExtension
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, string sortField, bool isAscendingSortOrder)
        {
            if (isAscendingSortOrder)
            {
                return query.OrderBy(sortField);
            }
            else
            {
                return query.OrderByDescending(sortField);
            }
        }
    }
}
