using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetails;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleTransferData;
using System.Threading.Tasks;
using Xunit;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehicleDetails.GetVehicleTransferData
{
    public class GetVehicleTransferDataControllerTests
    {
        private readonly GetVehicleTransferDataController _controller;
        private readonly Mock<IGetVehicleDetailsContext> _getVehiclesContext;
        private readonly string id = "existingId";
        public GetVehicleTransferDataControllerTests()
        {
            _getVehiclesContext = new Mock<IGetVehicleDetailsContext>();
            _controller = new GetVehicleTransferDataController(() => _getVehiclesContext.Object);
        }

        [Fact]
        public static void GetVehicleMustBeDecoratedWithHttpGetAttribute() =>
           typeof(GetVehicleTransferDataController)
            .GetMethod(nameof(GetVehicleTransferDataController.GetVehicleTechnicalComonents))
                                        .Should()
                                        .BeDecoratedWith<HttpGetAttribute>();

        [Fact]
        public async Task GetVehicleDetails_WithExistingId_ReturnsOkResult()
        {
            var vehicle = VehicleTransferDataTestHelper.GetTestVehicle();
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync(vehicle);

            var response = await _controller.GetVehicleTechnicalComonents(id);
            Assert.IsType<OkObjectResult>(response.Result);
        }  

        [Fact]
        public async Task GetVehicleDetails_WithExistingId_ReturnsRightItem()
        {
            var vehicle = VehicleTransferDataTestHelper.GetTestVehicle();
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync(vehicle);

            var result = (await _controller.GetVehicleTechnicalComonents(id)).Result as OkObjectResult;
            Assert.IsType<VehicleTransferDataResultDto>(result.Value);
        }

        [Fact]
        public async Task GetVehicleDetails_WithNotExistingId_ReturnsNotFoundResult()
        {
            var vehicle = new Vehicle();
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync((Vehicle)null);

            var response = await _controller.GetVehicleTechnicalComonents("notexistingId");
            Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicleDetails_WithoutId_ReturnsBadRequestResult()
        {
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync((Vehicle)null);

            var response = await _controller.GetVehicleTechnicalComonents(null);
            Assert.IsType<BadRequestResult>(response.Result);
        }
    }
}
