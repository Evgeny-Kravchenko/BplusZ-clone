using Synnotech_BplusZ.WebApi.Attributes;

namespace Synnotech_BplusZ.WebApi.Vehicles
{
    public interface IRolesBasedMapperService
    {
        TEntity Map<TEntity>(object source, string role, ActionType actionType);

        TDestination? Map<TSource, TDestination>(TSource source, TDestination destination, string role, ActionType actionType)
            where TDestination : class
            where TSource : class;
    }
}
