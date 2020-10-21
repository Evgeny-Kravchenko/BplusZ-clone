using Light.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using Synnotech_BplusZ.WebApi.Tokens.CreateToken;
using Synnotech_BplusZ.WebApi.Users;
using Synnotech_BplusZ.WebApi.Users.AuthorizeUser;
using System;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.AuthorizeUser
{
    [Route("api/users/authorize-user")]
    [ApiController]
    public class AuthorizeUserController : ControllerBase
    {
        private readonly Func<IAuthorizeUserContext> _createContext;
        private readonly ICreateTokenService _createTokenService;

        public AuthorizeUserController(Func<IAuthorizeUserContext> createContext,
            ICreateTokenService createTokenService)
        {
            _createContext = createContext.MustNotBeNull(nameof(createContext));
            _createTokenService = createTokenService.MustNotBeNull(nameof(createTokenService));
        }

        [HttpPost]
        public async Task<ActionResult<TokenDto>> AuthorizeUser([FromBody] AuthorizeUserDto dto)
        {
            if (dto == null 
                || dto.Email.IsNullOrWhiteSpace()
                || dto.Password.IsNullOrWhiteSpace())
            {
                return BadRequest();
            }

            using var context = _createContext();
            var user = await context.GetUserByEmail(dto.Email);

            if(user == null)
            {
                return NotFound();
            }

            var isVerified = PasswordHashHelper.VerifyHash(user, user.PasswordHash!, dto.Password);
            if(!isVerified)
            {
                return BadRequest();
            }

            var token = new TokenDto
            {
                Token = _createTokenService.CreateJWTToken(user.Id!, user.Role!),
            };

            return Ok(token);
        }
    }
}
