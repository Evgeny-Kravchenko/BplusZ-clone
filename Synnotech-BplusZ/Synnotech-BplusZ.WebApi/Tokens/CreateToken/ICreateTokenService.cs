namespace Synnotech_BplusZ.WebApi.Tokens.CreateToken
{
    public interface ICreateTokenService
    {
        string CreateJWTToken(string userId, string role);
    }
}
