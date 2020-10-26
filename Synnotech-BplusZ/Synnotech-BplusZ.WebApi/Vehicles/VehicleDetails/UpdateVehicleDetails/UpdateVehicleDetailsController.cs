using Light.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Users;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
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

        public UpdateVehicleDetailsController(Func<IUpdateVehicleDetailsContext> createContext)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

            using var context = _createContext();
            var existingVehicle = await context.GetVehicleDetails(id);
            if(existingVehicle == null)
            {
                return NotFound();
            }

            var vehicle = VehicleDetailsMapper.MapVehicleDetailsDto(dto);

            UpdateModel(existingVehicle, vehicle);
            var result = await context.UpdateVehicleDetails(existingVehicle);

            var vehicleResultDto = VehicleDetailsMapper.MapVehicleDetails(result);

            return Ok(vehicleResultDto);
        }

        private void UpdateModel(Vehicle dbVehicle, Vehicle newVehicle)
        {
            dbVehicle.GeneralData!.Manufacturer = newVehicle.GeneralData?.Manufacturer;
            dbVehicle.GeneralData!.Model = newVehicle.GeneralData?.Model;
            dbVehicle.GeneralData!.Status = newVehicle.GeneralData?.Status;
            dbVehicle.GeneralData!.ChassisNumber = newVehicle.GeneralData?.ChassisNumber;
            dbVehicle.GeneralData!.MileageDate = newVehicle.GeneralData?.MileageDate;
            dbVehicle.GeneralData!.VehicleClass = newVehicle.GeneralData?.VehicleClass;
            dbVehicle.TechnicalComponents!.ManufacturerStructure = newVehicle.TechnicalComponents?.ManufacturerStructure;
            dbVehicle.TechnicalComponents!.ConstructionType = newVehicle.TechnicalComponents?.ConstructionType;
            dbVehicle.TechnicalComponents!.LoadingBoard = newVehicle.TechnicalComponents?.LoadingBoard;
            dbVehicle.TechnicalComponents!.StandClimate = newVehicle.TechnicalComponents?.StandClimate;
            dbVehicle.TechnicalContractData!.MaintainanceAndRepair = newVehicle.TechnicalContractData?.MaintainanceAndRepair;
            dbVehicle.TechnicalContractData!.MileageInKmWPlusR = newVehicle.TechnicalContractData?.MileageInKmWPlusR;
            dbVehicle.TechnicalContractData!.EndOfMaintainanceAndRepair = newVehicle.TechnicalContractData?.EndOfMaintainanceAndRepair;
            dbVehicle.TransferData!.BranchOffice = newVehicle.TransferData?.BranchOffice;
        }
    }
}
