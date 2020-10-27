using AutoMapper;
using Light.GuardClauses;
using Synnotech_BplusZ.WebApi.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace Synnotech_BplusZ.WebApi.Vehicles
{
    public class RolesBasedMapperService : IRolesBasedMapperService
    {
        public TEntity Map<TEntity>(object source, string role, ActionType actionType)
        {
            var mapper = GetMapper<TEntity>(source, role, actionType);
             return mapper.Map<TEntity>(source);
        }

        public TDestination? Map<TSource, TDestination>(TSource source, TDestination destination, string role, ActionType actionType)
            where TDestination : class
            where TSource : class
        {
            var mapper = GetMapper<TDestination>(source, role, actionType);
            return mapper.Map(source, destination);
        }

        private IMapper GetMapper<TEntity>(object source, string role, ActionType actionType)
        {
            var configuration = CreateMapperConfiguration<TEntity>(source, role, actionType);
            return configuration.CreateMapper();
        }
        private MapperConfiguration CreateMapperConfiguration<TEntity>(object source, string role, ActionType actionType)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap(source.GetType(), typeof(TEntity))
                .ForAllMembers(opts =>
                {
                    opts.Condition(member =>
                    {
                        var memberName = member?.GetType().Name;
                        if (memberName.IsNullOrEmpty())
                            return false;

                        var currentProperty = source.GetType()?.GetProperty(memberName, BindingFlags.Public);
       
                        var attributes = currentProperty?.GetCustomAttributes<RequiredPermissionsAttribute>();
                        if (attributes == null)
                            return false;

                        if(attributes.Any(a => a.Roles.Contains(role)
                                               && (a.ActionType == ActionType.All || a.ActionType == actionType)))
                        {
                            return true;
                        }

                        return false;
                    });
                }));
        }


    }
}
