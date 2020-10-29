using Light.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Extensions;
using Synnotech_BplusZ.WebApi.Users;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetails;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingServices;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingModels;
using System;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleFinanceDetails
{
    [Route("api/vehicles/get-vehicle-finance-details/{id}")]
    [ApiController]
    [Authorize(Roles = UserRoles.FpOrGfOrNll)]
    public class GetVehicleFinanceDetailsController : ControllerBase
    {
        private readonly Func<IGetVehicleDetailsContext> _createContext;
        private readonly IVehicleFinanceMappingService _vehicleFinanceMappingService;

        public GetVehicleFinanceDetailsController(Func<IGetVehicleDetailsContext> createContext,
            IVehicleFinanceMappingService vehicleFinanceMappingService)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
            _vehicleFinanceMappingService = vehicleFinanceMappingService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VehicleFinanceDetailsDto>> GetVehicleDetailsFinance(string id)
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

            var vehicleDto = _vehicleFinanceMappingService
                .Map<VehicleFinanceDetailsDto>(vehicle, userRole, ActionType.Get);

            return Ok(vehicleDto);
        }
    }
}
