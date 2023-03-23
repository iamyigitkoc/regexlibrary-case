using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectAPI.Data;
using ProjectAPI.Helpers;
using ProjectAPI.Models;
using ProjectAPI.Provider;
using ProjectAPI.Request;
using ProjectAPI.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings _settings;
        private readonly IUserService _userService;
        private readonly IPasswordHashProvider _passwordHashProvider;

        public AuthService(IOptions<AppSettings> settings, IUserService userService, IPasswordHashProvider hashProvider)
        {
            _settings = settings.Value;
            _userService = userService;
            _passwordHashProvider = hashProvider;
        }

        public AuthResponse? Authenticate(AuthRequest request)
        {
            User? user = _userService.GetUserByUserName(request.UserName);
            if (user == null) return null;

            if (_passwordHashProvider.Verify(request.Password, user.Password)) {
                string token = GenerateToken(user);
                return new AuthResponse(user, token);
            }

            return null;
        }

        private string GenerateToken(User user) {
            var secureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var creadentials = new SigningCredentials(secureKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, "ProjectAPI"),
                new Claim(JwtRegisteredClaimNames.Email, ""),
                new Claim("Role", "Admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_settings.Issuer, _settings.Issuer, claims, expires: DateTime.Now.AddMinutes(20), signingCredentials: creadentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
