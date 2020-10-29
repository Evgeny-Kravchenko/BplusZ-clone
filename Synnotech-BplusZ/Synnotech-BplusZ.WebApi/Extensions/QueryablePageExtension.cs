
using System.Linq;

namespace Synnotech_BplusZ.WebApi.Extensions
{
    public static class QueryablePageExtension
    {
        public static IQueryable<TEntity> GetPage<TEntity>(this IQueryable<TEntity> query, int skip, int take)
        {
            return query.Skip(skip)
                        .Take(take);
        }
    }
}
