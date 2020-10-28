using Light.GuardClauses;
using Raven.Client.Documents;
using Raven.Client.Documents.Queries;
using Raven.Client.Documents.Session;
using SynDatabaseMigration.RavenDb;
using Synnotech_BplusZ.WebApi.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList
{
    public abstract class GetVehiclesBaseContext<TEntity, TIndexResult> : AsyncRavenSession
    {
        protected GetVehiclesBaseContext(IAsyncDocumentSession session) : base(session)
        {

        }

        public async Task<TPagedResult> GetVehicles<TPagedResult>(IQueryable<TIndexResult> sessionQuery,
            IGetVehicleDto dto,
            string sortField)
            where TPagedResult : PagedResult<TEntity>, new()
        {
            if (!dto.SearchTerm.IsNullOrEmpty())
            {
                var searchFieldSelector = GetFieldSelector(dto.SearchField?.FirstCharToUpper());

                if (dto.SearchField.IsNullOrEmpty())
                {
                    sessionQuery = sessionQuery.Search(searchFieldSelector, $"*{dto.SearchTerm}*");
                }
                else
                {
                    var terms = dto.SearchTerm.Split(' ').Select(t => $"*{t}*");
                    sessionQuery = sessionQuery.Search(searchFieldSelector, terms, @operator: SearchOperator.And);
                }
            }

            sessionQuery = sessionQuery.Where(GetPredicate())
                                             .OrderBy(sortField, dto.IsAscendingSortOrder);

            var count = await sessionQuery.CountAsync();
            var vehicles = await sessionQuery.GetPage(dto.Skip, dto.Take)
                                             .OfType<TEntity>()
                                             .ToListAsync();

            return new TPagedResult
            { 
                Count = count,
                Result = vehicles            
            };
        }

        protected abstract Expression<Func<TIndexResult, object?>> GetFieldSelector(string? field);

        protected abstract Expression<Func<TIndexResult, bool>> GetPredicate();
    }
}
