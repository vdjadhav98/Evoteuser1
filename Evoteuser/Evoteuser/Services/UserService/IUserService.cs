using evoting.DTO;
using evoting.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace evoting.Services.UserService
{
    public interface IUserService
    {
        public Task<User> CreateUser(User userObj);
        public Task<bool> UpdateUser(UpdateUserDTO updateUserDTO);
        public Task<bool> DeleteUser(DeleteUserDTO deleteUserDTO);
        public User Authentication(AuthenticationDTO authenticationDTO);
        
    }
}
