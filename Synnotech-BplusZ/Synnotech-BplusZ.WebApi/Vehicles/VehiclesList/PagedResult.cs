using System.Collections.Generic;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList
{
    public class PagedResult<TEntity>
    {
        public IEnumerable<TEntity>? Result { get; set; }
        public long Count { get; set; }
    }
}
