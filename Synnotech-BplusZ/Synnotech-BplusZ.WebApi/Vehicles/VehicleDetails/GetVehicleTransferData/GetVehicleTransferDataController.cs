using Light.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Extensions;
using Synnotech_BplusZ.WebApi.Users;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetails;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingModels;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingServices;
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
        private readonly IVehicleTransferDataMappingService _vehicleTransferDataMappingService;

        public GetVehicleTransferDataController(Func<IGetVehicleDetailsContext> createContext,
            IVehicleTransferDataMappingService vehicleTransferDataMappingService)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
            _vehicleTransferDataMappingService = vehicleTransferDataMappingService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VehicleTransferDataDto>> GetVehicleTechnicalComonents(string id)
        {
            if (id.IsNullOrWhiteSpace())
            {
                return BadRequest();
            }

            var userRole = User.GetRole();
            if (userRole.IsNullOrWhiteSpace())
            {
                return Forbid();
            }

            using var context = _createContext();
            var vehicle = await context.GetVehicleDetails(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleDto = _vehicleTransferDataMappingService
                .Map<VehicleTransferDataDto>(vehicle, userRole, ActionType.Get);

            return Ok(vehicleDto);
        }
    }
}
