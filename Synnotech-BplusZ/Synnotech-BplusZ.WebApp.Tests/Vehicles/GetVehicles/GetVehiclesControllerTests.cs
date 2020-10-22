using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.GetVehicles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.GetVehicles
{
    public class GetVehiclesControllerTests
    {
        private readonly GetVehiclesController _controller;
        private readonly Mock<IGetVehiclesContext> _getVehiclesContext;

        public GetVehiclesControllerTests()
        {
            _getVehiclesContext = new Mock<IGetVehiclesContext>();
            _controller = new GetVehiclesController(() => _getVehiclesContext.Object);
        }

        [Fact]
        public static void GetVehicleMustBeDecoratedWithHttpGetAttribute() =>
           typeof(GetVehiclesController).GetMethod(nameof(GetVehiclesController.GetVehicles))
                                        .Should()
                                        .BeDecoratedWith<HttpGetAttribute>();

        [Fact]
        public async Task GetVehicles_WithDto_ReturnsOkResult()
        {
            var vehicles = new List<Vehicle>().AsEnumerable();
            _getVehiclesContext.Setup(context => context.GetVehicles(It.IsAny<GetVehiclesDto>()))
                               .ReturnsAsync(vehicles);

            var response = await _controller.GetVehicles(new GetVehiclesDto());
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicles_WithDto_ReturnsRightItem()
        {
            var vehicles = new List<Vehicle>().AsEnumerable();
            _getVehiclesContext.Setup(context => context.GetVehicles(It.IsAny<GetVehiclesDto>()))
                               .ReturnsAsync(vehicles);

            var response = (await _controller.GetVehicles(new GetVehiclesDto())).Result as OkObjectResult;
            Assert.IsAssignableFrom<IEnumerable<VehicleResultDto>>(response.Value);
        }

        [Fact]
        public async Task GetVehicles_WithoutDto_ReturnsBadRequestResult()
        {
            var vehicles = new List<Vehicle>().AsEnumerable();
            _getVehiclesContext.Setup(context => context.GetVehicles(It.IsAny<GetVehiclesDto>()))
                               .ReturnsAsync(vehicles);

            var response = await _controller.GetVehicles(null);
            Assert.IsType<BadRequestResult>(response.Result);
        }
    }
}
