using Light.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Users;
using Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock
{
    [Route("api/vehicles/get-vehicles-stock")]
    [ApiController]
    [Authorize(Roles = UserRoles.NLL)]
    public class GetVehiclesStockController : ControllerBase
    {
        private readonly Func<IGetVehiclesStockContext> _createContext;

        public GetVehiclesStockController(Func<IGetVehiclesStockContext> createContext)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VehicleStockResultDto>>> GetVehiclesStock([FromQuery] GetVehiclesStockDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            using var context = _createContext();
            var vehicles = await context.GetStockVehicles(dto);
            var vehiclesDto = VehiclesStockMapper.MapVehicles(vehicles.Item1);

            return Ok(new { Result = vehiclesDto, Count = vehicles.Item2 });
        }
    }
}
