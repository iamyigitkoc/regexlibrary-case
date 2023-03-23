using ProjectAPI.Data;
using ProjectAPI.DTO;
using ProjectAPI.Models;
using ProjectAPI.Provider;
using ProjectAPI.Request;

namespace ProjectAPI.Services
{
    public class UserService : IUserService
    {
        private ApplicationDBContext _dbContext;

        private IPasswordHashProvider _passwordHashProvider;

        public UserService(ApplicationDBContext db, IPasswordHashProvider hashProvider) { 
            _dbContext = db;
            _passwordHashProvider = hashProvider;
        }

        public UserDTO Create(CreateUserRequest user) { 

            int userExisting = _dbContext.users.Where(u => u.UserName.Equals(user.UserName)).Count();

            if (userExisting <= 0) {
                User newUser = new User();
                newUser.UserName = this.NormalizeUserName(user.UserName);
                newUser.Password = _passwordHashProvider.Hash(user.Password);
                
                _dbContext.users.Add(newUser);
                _dbContext.SaveChanges();

                UserDTO newUserDTO = new UserDTO();
                newUserDTO.UserName = newUser.UserName;
                newUserDTO.Id = newUser.Id;
                return newUserDTO;
            }

            throw new Exception("Username \'"+user.UserName+"\' already exists");

        }

        public UserDTO? GetUserAsDTO(int id)
        {

            User? user = this.GetUser(id);

            if (user != null) { 
                UserDTO dto = new UserDTO();
                dto.Id = user.Id;
                dto.UserName = user.UserName;

                return dto;
            }

            return null;
        }

        public User? GetUser(int id) {
            return _dbContext.users.Find(id);
        }

        public User? GetUserByUserName(string userName) {
            string normalizedUsername = this.NormalizeUserName(userName);

            User? user = _dbContext.users.Where(u => u.UserName == normalizedUsername).FirstOrDefault();

            if (user != null)
            {
                return user;
            }

            return null;
        }

        private string NormalizeUserName(string username) {
            return username.ToLower();
        }
    }
}
