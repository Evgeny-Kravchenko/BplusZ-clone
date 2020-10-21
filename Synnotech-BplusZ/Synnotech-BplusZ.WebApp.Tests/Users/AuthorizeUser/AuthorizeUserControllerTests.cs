using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Synnotech_BplusZ.WebApi.Tokens.CreateToken;
using Synnotech_BplusZ.WebApi.Users.AuthorizeUser;
using Synnotech_BplusZ.WebApi.Users.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.AuthorizeUser;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.GetVehicles;
using Synnotech_BplusZ.WebApp.Tests.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Synnotech_BplusZ.WebApp.Tests.AuthorizeUser
{
    public class AuthorizeUserControllerTests
    {
        private readonly AuthorizeUserController _controller;
        private readonly Mock<IAuthorizeUserContext> _authorizeUserContext;
        private readonly Mock<ICreateTokenService> _createTokenService;
        private readonly string email = "testtest@mail.com";
        private readonly string password = "12345";

        public AuthorizeUserControllerTests()
        {
            _authorizeUserContext = new Mock<IAuthorizeUserContext>();
            _createTokenService = new Mock<ICreateTokenService>();
            _controller = new AuthorizeUserController(() => _authorizeUserContext.Object,
                _createTokenService.Object);
        }

        [Fact]
        public static void AuthorizeUserMustBeDecoratedWithHttpPostAttribute() =>
           typeof(AuthorizeUserController).GetMethod(nameof(AuthorizeUserController.AuthorizeUser))
                                          .Should()
                                          .BeDecoratedWith<HttpPostAttribute>();

        [Fact]
        public async Task AuthorizeUser_WithEmailAndPassword_ReturnsOkResult()
        {
            var user = UserTestHelper.GetTestUser(null, email, password);

            _authorizeUserContext.Setup(context => context.GetUserByEmail(It.IsAny<string>()))
                               .ReturnsAsync(user);

            var authorizeDto = new AuthorizeUserDto
            {
                Email = email,
                Password = password
            };
            var response = await _controller.AuthorizeUser(authorizeDto);
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task AuthorizeUser_WithoutEmailAndPassword_ReturnsBadRequestResult()
        {
            _authorizeUserContext.Setup(context => context.GetUserByEmail(It.IsAny<string>()))
                                 .ReturnsAsync((User)null);

            var response = await _controller.AuthorizeUser(new AuthorizeUserDto());
            Assert.IsType<BadRequestResult>(response.Result);
        }

        [Fact]
        public async Task AuthorizeUser_WithoutDto_ReturnsBadRequestResult()
        {
            _authorizeUserContext.Setup(context => context.GetUserByEmail(It.IsAny<string>()))
                                 .ReturnsAsync((User)null);

            var response = await _controller.AuthorizeUser(null);
            Assert.IsType<BadRequestResult>(response.Result);
        }

        [Fact]
        public async Task AuthorizeUser_WithNotExistingEmail_ReturnsNotFoundResult()
        {
            _authorizeUserContext.Setup(context => context.GetUserByEmail(It.IsAny<string>()))
                                 .ReturnsAsync((User)null);

            var authorizeDto = new AuthorizeUserDto
            {
                Email = "unexisting@mail.com",
                Password = password
            };

            var response = await _controller.AuthorizeUser(authorizeDto);
            Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public async Task AuthorizeUser_WithAnotherPassword_ReturnsBadRequestResult()
        {
            var user = UserTestHelper.GetTestUser(null, email, password);
            _authorizeUserContext.Setup(context => context.GetUserByEmail(It.IsAny<string>()))
                                 .ReturnsAsync(user);

            var authorizeDto = new AuthorizeUserDto
            {
                Email = email,
                Password = "another_pass"
            };

            var response = await _controller.AuthorizeUser(authorizeDto);
            Assert.IsType<BadRequestResult>(response.Result);
        }
    }
}
