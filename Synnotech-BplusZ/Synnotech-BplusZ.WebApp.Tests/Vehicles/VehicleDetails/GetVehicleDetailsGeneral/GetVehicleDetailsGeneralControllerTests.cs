using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetails;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetailsGeneral;
using System.Threading.Tasks;
using Xunit;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehicleDetails.GetVehicleDetailsGeneral
{
    public class GetVehicleDetailsGeneralControllerTests
    {
        private readonly GetVehicleDetailsGeneralController _controller;
        private readonly Mock<IGetVehicleDetailsContext> _getVehiclesContext;
        private readonly string id = "existingId";
        public GetVehicleDetailsGeneralControllerTests()
        {
            _getVehiclesContext = new Mock<IGetVehicleDetailsContext>();
            _controller = new GetVehicleDetailsGeneralController(() => _getVehiclesContext.Object);
        }

        [Fact]
        public static void GetVehicleMustBeDecoratedWithHttpGetAttribute() =>
           typeof(GetVehicleDetailsGeneralController).GetMethod(nameof(GetVehicleDetailsGeneralController.GetVehicleDetailsGeneral))
                                        .Should()
                                        .BeDecoratedWith<HttpGetAttribute>();

        [Fact]
        public async Task GetVehicleDetails_WithExistingId_ReturnsOkResult()
        {
            var vehicle = new Vehicle();
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync(vehicle);

            var response = await _controller.GetVehicleDetailsGeneral(id);
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicleDetails_WithExistingId_ReturnsRightItem()
        {
            var vehicle = new Vehicle
            {
                Id = id,
            };
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync(vehicle);

            var result = (await _controller.GetVehicleDetailsGeneral(id)).Result as OkObjectResult;
            Assert.IsType<VehicleDetailsGeneralResultDto>(result.Value);
            Assert.Equal(id, (result.Value as VehicleDetailsGeneralResultDto).Id);
        }

        [Fact]
        public async Task GetVehicleDetails_WithNotExistingId_ReturnsNotFoundResult()
        {
            var vehicle = new Vehicle();
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync((Vehicle)null);

            var response = await _controller.GetVehicleDetailsGeneral("notexistingId");
            Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicleDetails_WithoutId_ReturnsBadRequestResult()
        {
            _getVehiclesContext.Setup(context => context.GetVehicleDetails(It.IsAny<string>()))
                               .ReturnsAsync((Vehicle)null);

            var response = await _controller.GetVehicleDetailsGeneral(null);
            Assert.IsType<BadRequestResult>(response.Result);
        }
    }
}
