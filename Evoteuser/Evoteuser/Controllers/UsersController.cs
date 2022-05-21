
using evoting.DTO;
using evoting.Models;
using evoting.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evoting.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("api/[controller]/CreateUser")]
        public async Task<ActionResult<User>> CreateUser(User userObj)
        {
            if (ModelState.IsValid == true)
            {
                var userToCreate = await _userService.CreateUser(userObj);
                return Ok(userToCreate);
            }
            else
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }
        }

        [AllowAnonymous]
        [HttpPost("api/[controller]/Aunthentication")]
        public IActionResult Authentication([FromBody] AuthenticationDTO authenticationDTO)
        {
            var user = _userService.Authentication(authenticationDTO);
            if (user == null)
                return BadRequest(new { message = "UserName or Password is Incorrect" });

            return Ok(new { Id = user.UserId, Username = user.UserName });
        }

        [HttpPut]
        [Route("api/[controller]/UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserDTO updateUserDTO)
        {
            if (ModelState.IsValid == true)
            {
                var userToUpdate = await _userService.UpdateUser(updateUserDTO);
                if (userToUpdate == false)
                    return BadRequest(new { message = "UserName or Password is Incorrect" });
                return Ok(userToUpdate);
            }
            else
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }
        }

        [HttpPost]
        [Route("api/[controller]/DeleteUser")]
        public async Task<ActionResult<User>> DeleteUser([FromBody] DeleteUserDTO deleteUserDTO)
        {
            var userToDelete = await _userService.DeleteUser(deleteUserDTO);
            return Ok(userToDelete);
        }

        
        
    }
}
