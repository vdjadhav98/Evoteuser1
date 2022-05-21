using evoting.DTO;
using evoting.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evoting.Services.UserService
{
    public class UserService : IUserService
    {
        public static readonly List<User> Users = new List<User>()
{
  new User {UserId=1 , UserName="xyz", UserDOB="21", UserEmail="user@gmail.com", UserFullName="Xyz Xzy", UserGender="male",UserMobile=0, UserPassword="123"},
};


        public async Task<User> CreateUser(User userObj)
        {
            Users.Add(userObj);
            return userObj;
        }
        public async Task<bool> UpdateUser(UpdateUserDTO updateUserDTO)
        {

            var result = Users.Find(u => u.UserName.Equals(updateUserDTO.UserName) && u.UserPassword.Equals(updateUserDTO.UserOldPassword));
            if (result is null)
                return false;

            result.UserPassword = updateUserDTO.UserNewPassword;

            return true;
        }

        public async Task<bool> DeleteUser(DeleteUserDTO deleteUserDTO)
        {
            var result = Users.Find(u => u.UserId.Equals(deleteUserDTO.UserId));
            if (result is null)
                return false;

            Users.Remove(result);

            return true;
        }

        public User Authentication(AuthenticationDTO authenticationDTO)
        {
            return Users.SingleOrDefault(u => u.UserName.Equals(authenticationDTO.UserName) && u.UserPassword.Equals(authenticationDTO.Password));
            
        }

       
    }
}
