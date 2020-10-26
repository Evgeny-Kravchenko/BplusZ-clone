using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetails;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleTechnicalContractDetails;
using System.Threading.Tasks;
using Xunit;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehicleDetails.GetVehicleTechnicalContactDetails
{
    public class GetVehicleTechnicalContractDetailsControllerTests
    {
        private readonly GetVehicleTechnicalContractDetailsController _controller;
        private readonly Mock<IGetVehicleDetailsContext> _getVehiclesContext;
        private readonly string id = "existingId";

        public GetVehicleTechnicalContractDetailsControllerTests()
        {
            _getVehiclesContext = new Mock<IGetVehicleDetailsContext>();
            _controller = new GetVehicleTechnicalContractDetailsController(() => _getVehiclesContext.Object);
        }

        [Fact]
        public static void GetVehicleMustBeDecoratedWithHttpGetAttribute() =>
           typeof(GetVehicleTechnicalContractDetailsController)
            .GetMethod(nameof(GetVehicleTechnicalContractDetailsController.GetVehicleTechnicalContractDetails))
                                        .Should()
                                        .BeDecoratedWith<HttpGetAttribute>();

        [Fact]
        public async Task GetVehicleDetails_WithExistingId_ReturnsOkResult()
        {
            var vehicle = VehicleTechnicalContractDetailsTestHelper.GetTestVehicle();
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync(vehicle);

            var response = await _controller.GetVehicleTechnicalContractDetails(id);
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicleDetails_WithExistingId_ReturnsRightItem()
        {
            var vehicle = VehicleTechnicalContractDetailsTestHelper.GetTestVehicle();
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync(vehicle);

            var result = (await _controller.GetVehicleTechnicalContractDetails(id)).Result as OkObjectResult;
            Assert.IsType<VehicleTechnicalContractDetailsResultDto>(result.Value);
        }

        [Fact]
        public async Task GetVehicleDetails_WithNotExistingId_ReturnsNotFoundResult()
        {
            var vehicle = new Vehicle();
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync((Vehicle)null);

            var response = await _controller.GetVehicleTechnicalContractDetails("notexistingId");
            Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicleDetails_WithoutId_ReturnsBadRequestResult()
        {
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync((Vehicle)null);

            var response = await _controller.GetVehicleTechnicalContractDetails(null);
            Assert.IsType<BadRequestResult>(response.Result);
        }
    }
}
