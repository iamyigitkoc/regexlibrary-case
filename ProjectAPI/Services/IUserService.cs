using ProjectAPI.DTO;
using ProjectAPI.Models;
using ProjectAPI.Request;

namespace ProjectAPI.Services
{
    public interface IUserService
    {

        public UserDTO Create(CreateUserRequest user);

        public UserDTO? GetUserAsDTO(int id);

        public User? GetUser(int id);

        public User? GetUserByUserName(string username);

    }
}
