using AutoMapper;
using Light.GuardClauses;
using Synnotech_BplusZ.WebApi.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace Synnotech_BplusZ.WebApi.Mapping
{
    public abstract class RolesBasedMappingService<TSource> : IRolesBasedMappingService<TSource>
        where TSource : class
    {
        public TEntity Map<TEntity>(TSource source, string role, ActionType actionType)
            where TEntity : class
        {
            var mapper = GetMapper<TEntity>(source, role, actionType);
            return mapper.Map<TEntity>(source);
        }

        public TDestination? Map<TDestination>(TSource source, TDestination destination, string role, ActionType actionType)
            where TDestination : class
        {
            var mapper = GetMapper<TDestination>(source, role, actionType);
            return mapper.Map(source, destination);
        }

        private IMapper GetMapper<TEntity>(TSource source, string role, ActionType actionType)
            where TEntity : class
        {
            var configuration = CreateMapperConfiguration<TEntity>(source, role, actionType);
            return configuration.CreateMapper();
        }
        public abstract MapperConfiguration CreateMapperConfiguration<TEntity>(TSource source, string role, ActionType actionType)
            where TEntity : class;

        protected Func<object, bool> GetMapperCondition(string role, ActionType actionType)
        {
            var currentPropertyIndex = 0;
            return (member) =>
            {
                var props = member.GetType().GetProperties() ?? new PropertyInfo[] { };
                var currentProperty = props[currentPropertyIndex++];

                var attributes = currentProperty?.GetCustomAttributes<RequiredPermissionsAttribute>();
                if (attributes == null)
                    return true;

                if (!attributes.Any()
                   || attributes.Any(a => a.Roles.Contains(role)
                                          && (a.ActionType == ActionType.All || a.ActionType == actionType)))
                {
                    return true;
                }

                return false;
            };
        }
    }
}
