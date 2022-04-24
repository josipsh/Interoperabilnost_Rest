using System.Security.Claims;
using IisRest.Contracts.Auth;
using IisRest.Contracts.Dtos;
using IisRest.Contracts.Entities;
using IisRest.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace IisRest.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly UserManager<Profile> _userManager;

        public AuthService(UserManager<Profile> userManager, ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
        }

        public async Task<BasicLoginResponse> LogInAsync(BasicLoginRequest user)
        {
            Profile userDb = await FetchUserDataFromDB(user.Email, new Exception("Invalid Email Or Password"));

            bool isPaswordValid = await _userManager.CheckPasswordAsync(userDb, user.Password);

            if (!isPaswordValid)
            {
                throw new Exception("Invalid Email Or Password");
            }

            TokenHolder token = await GenerateToken(userDb);

            return new BasicLoginResponse()
            {
                Token = token.Token,
                ExpireAt = token.ExpiresAt,
            };
        }

        private async Task<Profile> FetchUserDataFromDB(string email, Exception exception)
        {
            Profile? userDb = await _userManager.FindByEmailAsync(email);

            if (userDb == null)
            {
                throw exception;
            }

            return userDb;
        }

        public async Task<BasicRegisterResponse> RegisterAsync(BasicRegisterRequest userData)
        {
            await IfUserAlreadyExistThrowException(userData.Email);

            if (!userData.IsPasswordEqual())
            {
                throw new Exception("Password must be same");
            }

            Profile user = userData.ToModel();

            IdentityResult result = await _userManager.CreateAsync(user, userData.Password);

            if (!result.Succeeded)
            {
                string errorMessage = string.Join(",", result.Errors.Select(x => x.Description));
                throw new Exception($"Unable to register. Error -> {errorMessage}");
            }

            IdentityResult addingClaimResult = await _userManager.AddClaimsAsync(user, new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserName", user.UserName),
                new Claim("Id", user.Id.ToString()),
            });

            if (!addingClaimResult.Succeeded)
            {
                string errorMessage = string.Join(",", addingClaimResult.Errors.Select(x => x.Description));
                throw new Exception($"Unable to register. Error -> {errorMessage}");
            }

            TokenHolder token = await GenerateToken(user);

            BasicRegisterResponse registeredUser = user.ToRegisterResponse();
            registeredUser.Token = token.Token;
            registeredUser.ExpireAt = token.ExpiresAt;

            return registeredUser;
        }

        private async Task<TokenHolder> GenerateToken(Profile user)
        {
            IList<Claim> claims = await _userManager.GetClaimsAsync(user);

            return _tokenGenerator.GenerateToken(claims.ToList());
        }

        private async Task IfUserAlreadyExistThrowException(string email)
        {
            Profile? existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser != null)
            {
                throw new Exception("User with this email alredy exist");
            }
        }
    }
}
