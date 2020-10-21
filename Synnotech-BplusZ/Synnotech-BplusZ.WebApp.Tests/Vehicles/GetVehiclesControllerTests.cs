using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Vehicles.GetVehicles;
using Xunit;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles
{
    public class GetVehiclesControllerTests
    {
        private readonly GetVehiclesController _controller;

        [Fact]
        public static void GetVehicleMustBeDecoratedWithHttpGetAttribute() =>
           typeof(GetVehiclesController).GetMethod(nameof(GetVehiclesController.GetVehicles)).Should().BeDecoratedWith<HttpGetAttribute>();


    }
}
