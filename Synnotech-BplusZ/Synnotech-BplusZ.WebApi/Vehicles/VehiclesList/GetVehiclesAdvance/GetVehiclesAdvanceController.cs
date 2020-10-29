using AutoMapper;
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
    [Authorize(Roles = UserRoles.FpOrGfOrNll)]
    public class GetVehiclesAdvanceController : ControllerBase
    {
        private readonly Func<IGetVehiclesAdvanceContext> _createContext;
        private readonly IMapper _mapper;

        public GetVehiclesAdvanceController(Func<IGetVehiclesAdvanceContext> createContext,
            IMapper mapper)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VehicleAdvancePagedResultDto>> GetVehiclesAdvance([FromQuery] GetVehiclesAdvancedDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            using var context = _createContext();
            var pagedResult = await context.GetVehiclesAdvance(dto);
            var vehiclesDto = _mapper.Map<VehicleAdvancePagedResultDto>(pagedResult);

            return Ok(vehiclesDto);
        }
    }
}
