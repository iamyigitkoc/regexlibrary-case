using Microsoft.IdentityModel.Tokens;
using ProjectAPI.DTO;
using ProjectAPI.Models;
using ProjectAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ProjectAPI.Helpers
{
    public class JwtMiddleware
    {

        private readonly RequestDelegate _next;

        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, AppSettings appSettings)
        {
            _next = next;
            _appSettings = appSettings;
        }

        public async Task InvokeAsync(HttpContext context, IUserService userService) {
            var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(' ').Last();
            if (token != null) {
                
            }
            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = key,
                    ValidIssuer = _appSettings.Issuer,
                    ValidAudience = _appSettings.Issuer,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                // attach user to context on successful jwt validation
                User? user = userService.GetUser(userId);
                if (user != null) {
                    context.Items["User"] = user;
                }
            }
            catch (Exception)
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}

