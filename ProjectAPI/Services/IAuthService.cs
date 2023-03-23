using ProjectAPI.Request;
using ProjectAPI.Response;

namespace ProjectAPI.Services
{
    public interface IAuthService
    {

        AuthResponse? Authenticate(AuthRequest request);

    }
}
