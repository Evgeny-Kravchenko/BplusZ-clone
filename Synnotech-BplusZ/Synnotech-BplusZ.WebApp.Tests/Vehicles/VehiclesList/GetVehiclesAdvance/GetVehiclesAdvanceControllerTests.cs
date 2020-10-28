using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehiclesList;
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
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new VehicleAdvanceProfile());
            });
            var mapper = mockMapper.CreateMapper();
            _getVehiclesContext = new Mock<IGetVehiclesAdvanceContext>();

            _controller = new GetVehiclesAdvanceController(() => _getVehiclesContext.Object, mapper);
        }

        [Fact]
        public static void GetVehicleMustBeDecoratedWithHttpGetAttribute() =>
           typeof(GetVehiclesAdvanceController).GetMethod(nameof(GetVehiclesAdvanceController.GetVehiclesAdvance))
                                        .Should()
                                        .BeDecoratedWith<HttpGetAttribute>();

        [Fact]
        public async Task GetVehicles_WithDto_ReturnsOkResult()
        {
            var vehiclesResult = GetPagedResult();
            _getVehiclesContext.Setup(context => context.GetVehiclesAdvance(It.IsAny<GetVehiclesAdvancedDto>()))
                               .ReturnsAsync(vehiclesResult);

            var response = await _controller.GetVehiclesAdvance(new GetVehiclesAdvancedDto());
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task GetVehicles_WithDto_ReturnsRightItem()
        {
            var vehiclesResult = GetPagedResult();
            _getVehiclesContext.Setup(context => context.GetVehiclesAdvance(It.IsAny<GetVehiclesAdvancedDto>()))
                               .ReturnsAsync(vehiclesResult);

            var response = (await _controller.GetVehiclesAdvance(new GetVehiclesAdvancedDto())).Result as OkObjectResult;
            Assert.IsType<VehicleAdvancePagedResultDto>(response.Value);
        }

        [Fact]
        public async Task GetVehicles_WithoutDto_ReturnsBadRequestResult()
        {
            var vehiclesResult = GetPagedResult();
            _getVehiclesContext.Setup(context => context.GetVehiclesAdvance(It.IsAny<GetVehiclesAdvancedDto>()))
                               .ReturnsAsync(vehiclesResult);

            var response = await _controller.GetVehiclesAdvance(null);
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
