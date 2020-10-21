using Light.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.GetVehicles
{
    [Route("api/vehicles/get-vehicles")]
    [ApiController]
    [Authorize(Roles = UserRoles.NNL)]
    public class GetVehiclesController : ControllerBase
    {
        private readonly Func<IGetVehiclesContext> _createContext;

        public GetVehiclesController(Func<IGetVehiclesContext> createContext)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleResultDto>>> GetVehicles([FromQuery] GetVehiclesDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            using var context = _createContext();
            var vehicles = await context.GetVehicles(dto);
            var vehiclesDto = VehicleMapper.MapVehicles(vehicles);

            return Ok(vehiclesDto);
        }
    }
}
