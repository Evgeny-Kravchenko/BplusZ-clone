using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehiclesList;
using Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehiclesList.GetVehiclesStock
{
    public class GetVehiclesStockControllerTests
    {
        private readonly GetVehiclesStockController _controller;
        private readonly Mock<IGetVehiclesStockContext> _getVehiclesContext;

        public GetVehiclesStockControllerTests()
        {
            _getVehiclesContext = new Mock<IGetVehiclesStockContext>();
            _controller = new GetVehiclesStockController(() => _getVehiclesContext.Object);
        }

        [Fact]
        public static void GetVehicleMustBeDecoratedWithHttpGetAttribute() =>
           typeof(GetVehiclesStockController).GetMethod(nameof(GetVehiclesStockController.GetVehiclesStock))
                                        .Should()
                                        .BeDecoratedWith<HttpGetAttribute>();

        [Fact]
        public async Task GetVehicles_WithDto_ReturnsOkResult()
        {
            var vehicles = new List<Vehicle>().AsEnumerable();
            _getVehiclesContext.Setup(context => context.GetStockVehicles(It.IsAny<GetVehiclesDto>()))
                               .ReturnsAsync(vehicles);

            var response = await _controller.GetVehiclesStock(new GetVehiclesDto());
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicles_WithDto_ReturnsRightItem()
        {
            var vehicles = new List<Vehicle>().AsEnumerable();
            _getVehiclesContext.Setup(context => context.GetStockVehicles(It.IsAny<GetVehiclesDto>()))
                               .ReturnsAsync(vehicles);

            var response = (await _controller.GetVehiclesStock(new GetVehiclesDto())).Result as OkObjectResult;
            Assert.IsAssignableFrom<IEnumerable<VehicleStockResultDto>>(response.Value);
        }

        [Fact]
        public async Task GetVehicles_WithoutDto_ReturnsBadRequestResult()
        {
            var vehicles = new List<Vehicle>().AsEnumerable();
            _getVehiclesContext.Setup(context => context.GetStockVehicles(It.IsAny<GetVehiclesDto>()))
                               .ReturnsAsync(vehicles);

            var response = await _controller.GetVehiclesStock(null);
            Assert.IsType<BadRequestResult>(response.Result);
        }
    }
}
