using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehiclesList.GetVehiclesAdvance
{
    public class GetVehiclesAdvanceControllerTests
    {
        private readonly GetVehiclesAdvanceController _controller;
        private readonly Mock<IGetVehiclesAdvanceContext> _getVehiclesContext;

        public GetVehiclesAdvanceControllerTests()
        {
            _getVehiclesContext = new Mock<IGetVehiclesAdvanceContext>();
            _controller = new GetVehiclesAdvanceController(() => _getVehiclesContext.Object);
        }

        [Fact]
        public static void GetVehicleMustBeDecoratedWithHttpGetAttribute() =>
           typeof(GetVehiclesAdvanceController).GetMethod(nameof(GetVehiclesAdvanceController.GetVehiclesAdvance))
                                        .Should()
                                        .BeDecoratedWith<HttpGetAttribute>();

        [Fact]
        public async Task GetVehicles_WithDto_ReturnsOkResult()
        {
            var vehicles = new List<Vehicle>().AsEnumerable();
            _getVehiclesContext.Setup(context => context.GetVehiclesAdvance(It.IsAny<GetVehiclesAdvancedDto>()))
                               .ReturnsAsync(vehicles);

            var response = await _controller.GetVehiclesAdvance(new GetVehiclesAdvancedDto());
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicles_WithDto_ReturnsRightItem()
        {
            var vehicles = new List<Vehicle>().AsEnumerable();
            _getVehiclesContext.Setup(context => context.GetVehiclesAdvance(It.IsAny<GetVehiclesAdvancedDto>()))
                               .ReturnsAsync(vehicles);

            var response = (await _controller.GetVehiclesAdvance(new GetVehiclesAdvancedDto())).Result as OkObjectResult;
            Assert.IsAssignableFrom<IEnumerable<VehicleAdvanceResultDto>>(response.Value);
        }

        [Fact]
        public async Task GetVehicles_WithoutDto_ReturnsBadRequestResult()
        {
            var vehicles = new List<Vehicle>().AsEnumerable();
            _getVehiclesContext.Setup(context => context.GetVehiclesAdvance(It.IsAny<GetVehiclesAdvancedDto>()))
                               .ReturnsAsync(vehicles);

            var response = await _controller.GetVehiclesAdvance(null);
            Assert.IsType<BadRequestResult>(response.Result);
        }
    }
}
