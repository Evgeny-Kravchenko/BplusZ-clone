using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehiclesList;
using Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance;
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
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new VehicleStockProfile());
            });
            var mapper = mockMapper.CreateMapper();
            _getVehiclesContext = new Mock<IGetVehiclesStockContext>();
            _controller = new GetVehiclesStockController(() => _getVehiclesContext.Object, mapper);
        }

        [Fact]
        public static void GetVehicleMustBeDecoratedWithHttpGetAttribute() =>
           typeof(GetVehiclesStockController).GetMethod(nameof(GetVehiclesStockController.GetVehiclesStock))
                                        .Should()
                                        .BeDecoratedWith<HttpGetAttribute>();

        [Fact]
        public async Task GetVehicles_WithDto_ReturnsOkResult()
        {
            var vehiclesPaged = GetPagedResult();
            _getVehiclesContext.Setup(context => context.GetStockVehicles(It.IsAny<GetVehiclesStockDto>()))
                               .ReturnsAsync(vehiclesPaged);

            var response = await _controller.GetVehiclesStock(new GetVehiclesStockDto());
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicles_WithDto_ReturnsRightItem()
        {
            var vehiclesPaged = GetPagedResult();
            _getVehiclesContext.Setup(context => context.GetStockVehicles(It.IsAny<GetVehiclesStockDto>()))
                               .ReturnsAsync(vehiclesPaged);

            var response = (await _controller.GetVehiclesStock(new GetVehiclesStockDto())).Result as OkObjectResult;
            Assert.IsType<VehicleStockPagedResultDto>(response.Value);
        }

        [Fact]
        public async Task GetVehicles_WithoutDto_ReturnsBadRequestResult()
        {
            var vehiclesPaged = GetPagedResult();
            _getVehiclesContext.Setup(context => context.GetStockVehicles(It.IsAny<GetVehiclesStockDto>()))
                               .ReturnsAsync(vehiclesPaged);

            var response = await _controller.GetVehiclesStock(null);
            Assert.IsType<BadRequestResult>(response.Result);
        }

        private VehiclePagedResult GetPagedResult()
        {
            return new VehiclePagedResult
            {
                Result = new List<Vehicle>().AsEnumerable(),
                Count = 0
            };
        }
    }
}
