using System.Security.Claims;
using IisRest.Contracts.Entities;

namespace IisRest.Contracts.Auth
{
    public interface ITokenGenerator
    {
        TokenHolder GenerateToken(List<Claim> claims);
    }
}
