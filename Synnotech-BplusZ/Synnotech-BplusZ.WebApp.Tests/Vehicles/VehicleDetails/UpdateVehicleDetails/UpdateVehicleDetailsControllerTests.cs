using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingServices;
using System.Threading.Tasks;
using Xunit;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehicleDetails.UpdateVehicleDetails
{
    public class UpdateVehicleDetailsControllerTests
    {
        private readonly UpdateVehicleDetailsController _controller;
        private readonly Mock<IUpdateVehicleDetailsContext> _getVehiclesContext;
        private readonly Mock<IUpdateVehicleMappingService> _updateVehicleMappingService;
        private readonly Mock<IVehicleMappingService> _vehicleMappingService;
        private readonly string id = "existingId";
        private readonly string notexistingId = "notexistingId";
        public UpdateVehicleDetailsControllerTests()
        {
            _getVehiclesContext = new Mock<IUpdateVehicleDetailsContext>();
            _updateVehicleMappingService = new Mock<IUpdateVehicleMappingService>();
            _vehicleMappingService = new Mock<IVehicleMappingService>();
            _controller = new UpdateVehicleDetailsController(() => _getVehiclesContext.Object,
            _updateVehicleMappingService.Object,
            _vehicleMappingService.Object);
        }

        [Fact]
        public static void GetVehicleMustBeDecoratedWithHttpGetAttribute() =>
           typeof(UpdateVehicleDetailsController).GetMethod(nameof(UpdateVehicleDetailsController.UpdateVehicleDetails))
                                        .Should()
                                        .BeDecoratedWith<HttpPutAttribute>();

        [Fact]
        public async Task GetVehicleDetails_WithExistingId_ReturnsOkResult()
        {
            var vehicle = VehicleTestHelper.GetTestVehicleDetails(id);
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync(vehicle);
            _getVehiclesContext.Setup(context => context.UpdateVehicleDetails(It.IsAny<Vehicle>()))
                               .ReturnsAsync(vehicle);

            var vehicleDto = VehicleTestHelper.GetTestVehicleDetailsDto(id);
            var response = await _controller.UpdateVehicleDetails(id, vehicleDto);
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicleDetails_WithExistingId_ReturnsRightItem()
        {
            var vehicle = VehicleTestHelper.GetTestVehicleDetails(id);
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync(vehicle);
            _getVehiclesContext.Setup(context => context.UpdateVehicleDetails(It.IsAny<Vehicle>()))
                              .ReturnsAsync(vehicle);

            var newVehicle = VehicleTestHelper.GetTestVehicleDetailsDto(id);
            var result = (await _controller.UpdateVehicleDetails(id, newVehicle)).Result as OkObjectResult;
            Assert.IsType<UpdateVehicleDetailsDto>(result.Value);
            Assert.Equal(id, (result.Value as UpdateVehicleDetailsDto).Id);
        }

        [Fact]
        public async Task GetVehicleDetails_WithExistingId_UpdatesRightFields()
        {
            var vehicle = VehicleTestHelper.GetTestVehicleDetails(id);
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync(vehicle);
            _getVehiclesContext.Setup(context => context.UpdateVehicleDetails(It.IsAny<Vehicle>()))
                              .ReturnsAsync(vehicle);

            var newVehicle = VehicleTestHelper.GetTestVehicleDetailsDto(id);
            var result = (await _controller.UpdateVehicleDetails(id, newVehicle)).Result as OkObjectResult;
            var updatedVehicle = result.Value as UpdateVehicleDetailsDto;
            Assert.Equal(newVehicle.GeneralData!.Manufacturer, updatedVehicle.GeneralData!.Manufacturer);
            Assert.Equal(newVehicle.GeneralData!.Model, updatedVehicle.GeneralData!.Model);
            Assert.Equal(newVehicle.GeneralData!.Status, updatedVehicle.GeneralData!.Status);
            Assert.Equal(newVehicle.GeneralData!.ChassisNumber, updatedVehicle.GeneralData!.ChassisNumber);
            Assert.Equal(newVehicle.GeneralData!.MileageDate, updatedVehicle.GeneralData!.MileageDate);
            Assert.Equal(newVehicle.GeneralData!.VehicleClass, updatedVehicle.GeneralData!.VehicleClass);
            
            Assert.Equal(newVehicle.TechnicalComponents!.ManufacturerStructure, updatedVehicle.TechnicalComponents!.ManufacturerStructure);
            Assert.Equal(newVehicle.TechnicalComponents!.ConstructionType, updatedVehicle.TechnicalComponents!.ConstructionType);
            Assert.Equal(newVehicle.TechnicalComponents!.LoadingBoard, updatedVehicle.TechnicalComponents!.LoadingBoard);
            Assert.Equal(newVehicle.TechnicalComponents!.StandClimate, updatedVehicle.TechnicalComponents!.StandClimate);

            Assert.Equal(newVehicle.TechnicalContractData!.MaintainanceAndRepair, updatedVehicle.TechnicalContractData!.MaintainanceAndRepair);
            Assert.Equal(newVehicle.TechnicalContractData!.MileageInKmWPlusR, updatedVehicle.TechnicalContractData!.MileageInKmWPlusR);
            Assert.Equal(newVehicle.TechnicalContractData!.EndOfMaintainanceAndRepair, updatedVehicle.TechnicalContractData!.EndOfMaintainanceAndRepair);

            Assert.Equal(newVehicle.TransferData!.BranchOffice, updatedVehicle.TransferData!.BranchOffice);
        }

        [Fact]
        public async Task GetVehicleDetails_WithNotExistingId_ReturnsNotFoundResult()
        {
            var vehicle = VehicleTestHelper.GetTestVehicleDetails(id);
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync((Vehicle)null);
            _getVehiclesContext.Setup(context => context.UpdateVehicleDetails(It.IsAny<Vehicle>()))
                              .ReturnsAsync(vehicle);

            var vehicleDto = VehicleTestHelper.GetTestVehicleDetailsDto(notexistingId);
            var response = await _controller.UpdateVehicleDetails(notexistingId, vehicleDto);
            Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicleDetails_WithoutId_ReturnsBadRequestResult()
        {
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync((Vehicle)null);

            var response = await _controller.UpdateVehicleDetails(null, new UpdateVehicleDetailsDto());
            Assert.IsType<BadRequestResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicleDetails_WithoutDifferentIdInDtoAndRoute_ReturnsBadRequestResult()
        {
            var vehicleDto = VehicleTestHelper.GetTestVehicleDetailsDto(id);
            var response = await _controller.UpdateVehicleDetails(notexistingId, vehicleDto);
            Assert.IsType<BadRequestResult>(response.Result);
        }
    }
}
