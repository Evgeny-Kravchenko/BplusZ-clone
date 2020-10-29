using Synnotech_BplusZ.WebApi.Attributes;

namespace Synnotech_BplusZ.WebApi.Mapping
{
    public interface IRolesBasedMappingService<TSource>
        where TSource : class
    {
        TDestination Map<TDestination>(TSource source, string role, ActionType actionType)
            where TDestination : class;

        TDestination? Map<TDestination>(TSource source, TDestination destination, string role, ActionType actionType)
            where TDestination : class;
            
    }
}
