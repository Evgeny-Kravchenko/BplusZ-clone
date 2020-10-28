using Light.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance
{
    [Route("api/vehicles/get-vehicles-advance")]
    [ApiController]
    [Authorize(Roles = UserRoles.NLL)]
    public class GetVehiclesAdvanceController : ControllerBase
    {
        private readonly Func<IGetVehiclesAdvanceContext> _createContext;

        public GetVehiclesAdvanceController(Func<IGetVehiclesAdvanceContext> createContext)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetVehiclesAdvance([FromQuery] GetVehiclesAdvancedDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            using var context = _createContext();
            var vehicles = await context.GetVehiclesAdvance(dto);
            var vehiclesDto = VehiclesAdvanceMapper.MapVehicles(vehicles.Item1);

            return Ok(new { Result = vehiclesDto, Count = vehicles.Item2});
        }
    }
}
