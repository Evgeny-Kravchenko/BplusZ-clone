using Light.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Extensions;
using Synnotech_BplusZ.WebApi.Users;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetails;
using System;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleGeneralDetails
{
    [Route("api/vehicles/get-vehicle-general-details/{id}")]
    [ApiController]
    [Authorize(Roles = UserRoles.FpOrGfOrNll)]
    public class GetVehicleGeneralDetailsController : ControllerBase
    {
        private readonly Func<IGetVehicleDetailsContext> _createContext;
        private readonly IVehicleGeneralMappingService _vehicleMappingService;

        public GetVehicleGeneralDetailsController(Func<IGetVehicleDetailsContext> createContext,
            IVehicleGeneralMappingService vehicleGeneralMappingService)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
            _vehicleMappingService = vehicleGeneralMappingService.MustNotBeNull(nameof(vehicleGeneralMappingService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VehicleDetailsGeneralDto>> GetVehicleDetailsGeneral(string id)
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

            var vehicleDto =_vehicleMappingService.Map<VehicleDetailsGeneralDto>(vehicle, userRole, Attributes.ActionType.Get);

            return Ok(vehicleDto);
        }
    }
}
