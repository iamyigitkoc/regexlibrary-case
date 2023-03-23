using ProjectAPI.Models;

namespace ProjectAPI.Response
{
    public class AuthResponse
    {

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }

        public AuthResponse(User user, string token) { 
            Id = user.Id;
            UserName = user.UserName;
            Token = token;
        }

    }
}
