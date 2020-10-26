using Light.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Users;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetails;
using System;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleTransferData
{
    [Route("api/vehicles/get-vehicle-transfer-data/{id}")]
    [ApiController]
    [Authorize(Roles = UserRoles.FpOrGfOrNll)]
    public class GetVehicleTransferDataController : ControllerBase
    {
        private readonly Func<IGetVehicleDetailsContext> _createContext;

        public GetVehicleTransferDataController(Func<IGetVehicleDetailsContext> createContext)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VehicleTransferDataResultDto>> GetVehicleTechnicalComonents(string id)
        {
            if (id.IsNullOrWhiteSpace())
            {
                return BadRequest();
            }

            using var context = _createContext();
            var vehicle = await context.GetVehicleDetails(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleDto = VehicleTransferDataMapper.MapVehicleDetails(vehicle);

            return Ok(vehicleDto);
        }
    }
}
