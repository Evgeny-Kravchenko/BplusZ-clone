using Light.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Users;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetails;
using System;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetailsFinance
{
    [Route("api/vehicles/get-vehicle-details-finance/{id}")]
    [ApiController]
    [Authorize(Roles = UserRoles.NLL)]
    public class GetVehicleFinanceDetailsController : ControllerBase
    {
        private readonly Func<IGetVehicleDetailsContext> _createContext;

        public GetVehicleFinanceDetailsController(Func<IGetVehicleDetailsContext> createContext)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VehicleFinanceDetailsResultDto>> GetVehicleDetailsFinance(string id)
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

            var vehicleDto = VehicleFinanceDetailsMapper.MapVehicleDetails(vehicle);

            return Ok(vehicleDto);
        }
    }
}
