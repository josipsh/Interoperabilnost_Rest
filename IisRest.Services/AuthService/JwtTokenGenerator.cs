using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IisRest.Contracts.Auth;
using IisRest.Contracts.Entities;
using IisRest.Contracts.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IisRest.Services.AuthService
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly JwtSettings _settings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
        {
            _settings = jwtSettings.Value;
        }

        public TokenHolder GenerateToken(List<Claim> claims)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(_settings.Key);
            SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(keyBytes);

            DateTime expireAt = DateTime.Now.AddHours(_settings.ValidHours);

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                    issuer: _settings.Issuer,
                    audience: _settings.Audience,
                    expires: expireAt,
                    claims: claims,
                    signingCredentials: new SigningCredentials(
                            authSigningKey,
                            SecurityAlgorithms.HmacSha256));

            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return new TokenHolder()
            {
                Token = token,
                ExpiresAt = expireAt,
            };
        }
    }
}
