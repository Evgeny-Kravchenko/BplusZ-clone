using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetails;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleTechnicalComponentsDetails;
using System.Threading.Tasks;
using Xunit;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehicleDetails.GetVehicleTechnicalComponents
{
    public class GetVehicleFinanceDetailsControllerTests
    {
        private readonly GetVehicleTechnicalComponentsController _controller;
        private readonly Mock<IGetVehicleDetailsContext> _getVehiclesContext;
        private readonly string id = "existingId";
        public GetVehicleFinanceDetailsControllerTests()
        {
            _getVehiclesContext = new Mock<IGetVehicleDetailsContext>();
            _controller = new GetVehicleTechnicalComponentsController(() => _getVehiclesContext.Object);
        }

        [Fact]
        public static void GetVehicleMustBeDecoratedWithHttpGetAttribute() =>
           typeof(GetVehicleTechnicalComponentsController)
            .GetMethod(nameof(GetVehicleTechnicalComponentsController.GetVehicleTechnicalComonents))
                                        .Should()
                                        .BeDecoratedWith<HttpGetAttribute>();

        [Fact]
        public async Task GetVehicleDetails_WithExistingId_ReturnsOkResult()
        {
            var vehicle = VehicleTechnicalComponentsTestHelper.GetTestVehicle();
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync(vehicle);

            var response = await _controller.GetVehicleTechnicalComonents(id);
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicleDetails_WithExistingId_ReturnsRightItem()
        {
            var vehicle = VehicleTechnicalComponentsTestHelper.GetTestVehicle();
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync(vehicle);

            var result = (await _controller.GetVehicleTechnicalComonents(id)).Result as OkObjectResult;
            Assert.IsType<VehicleTechnicalComponentsResultDto>(result.Value);
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
