using AutoMapper;
using Light.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock
{
    [Route("api/vehicles/get-vehicles-stock")]
    [ApiController]
    [Authorize(Roles = UserRoles.FpOrGfOrNll)]
    public class GetVehiclesStockController : ControllerBase
    {
        private readonly Func<IGetVehiclesStockContext> _createContext;
        private readonly IMapper _mapper;

        public GetVehiclesStockController(Func<IGetVehiclesStockContext> createContext,
            IMapper mapper)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
            _mapper = mapper;
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
            var pagedResult = await context.GetStockVehicles(dto);
            var vehiclesDto = _mapper.Map<VehicleStockPagedResultDto>(pagedResult);

            return Ok(vehiclesDto);
        }
    }
}
