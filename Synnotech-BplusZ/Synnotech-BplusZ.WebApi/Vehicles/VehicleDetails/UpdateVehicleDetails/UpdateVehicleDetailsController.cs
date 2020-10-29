using Light.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Extensions;
using Synnotech_BplusZ.WebApi.Users;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingModels;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingServices;
using System;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails
{
    [Route("api/vehicles/update-vehicle-details/{id}")]
    [ApiController]
    [Authorize(Roles = UserRoles.FpOrGfOrNll)]
    public class UpdateVehicleDetailsController : ControllerBase
    {
        private readonly Func<IUpdateVehicleDetailsContext> _createContext;
        private readonly IUpdateVehicleMappingService _updateVehicleMappingService;
        private readonly IVehicleMappingService _vehicleMappingService;

        public UpdateVehicleDetailsController(Func<IUpdateVehicleDetailsContext> createContext,
            IUpdateVehicleMappingService updateVehicleMappingService,
            IVehicleMappingService vehicleMappingService)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
            _updateVehicleMappingService = updateVehicleMappingService;
            _vehicleMappingService = vehicleMappingService;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateVehicleDetailsDto>> UpdateVehicleDetails(string id,
            [FromBody] UpdateVehicleDetailsDto dto)
        {
            if (id.IsNullOrWhiteSpace()
                || dto == null
                || dto.Id != id)
            {
                return BadRequest();
            }

            var userRole = User.GetRole();
            if (userRole.IsNullOrWhiteSpace())
            {
                return Forbid();
            }

            using var context = _createContext();
            var existingVehicle = await context.GetVehicleDetails(id);
            if(existingVehicle == null)
            {
                return NotFound();
            }

            var vehicle = _updateVehicleMappingService.Map(dto, existingVehicle, userRole, ActionType.Update);
            var result = await context.UpdateVehicleDetails(vehicle!);

            var vehicleResultDto = _vehicleMappingService.Map<VehicleDetailsDto>(result, userRole, ActionType.Update);

            return Ok(vehicleResultDto);
        }
    }
}
