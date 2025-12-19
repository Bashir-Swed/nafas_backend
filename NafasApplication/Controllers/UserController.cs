using Microsoft.AspNetCore.Mvc;
using Nafas.BLL.Services;
using Nafas.DAL.DTOs;
using Nafas.DAL.DTOs.User;
using Nafas.DAL.Repositories;

namespace NafasApplication.Controllers
{
    [ApiController]
    [Route("/api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly userService _userService = new userService();
        [HttpPost("")]
        public ActionResult<int?> AddNewUser(NewUserDTO user)
        {
            try
            {
                return Ok(_userService.AddNewUser(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("change-password")]
        public ActionResult<bool> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            try
            {
                return Ok(_userService.ChangePassword(changePasswordDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("")]
        public ActionResult<UserProfileDTO?> GetUserProfile(int userID)
        {
            try
            {
                return Ok(_userService.GetUserProfile(userID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("exists/{userID}")]
        public ActionResult<bool> CheckUserByID(int userID)
        {
            try
            {
                return Ok(_userService.CheckUserByID(userID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("exists")]
        public ActionResult<bool>? CheckUserByName(string userName)
        {
            try
            {
                return Ok(_userService.CheckUserByName(userName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("exists/{password}/{username}")]
        public ActionResult<bool>? CheckUserByNameAndPassword(string username, string password)
        {
            try
            {
                return Ok(_userService.CheckUserByNameAndPassword(username, password));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateUserName")]
        public ActionResult<bool> UpdateUserName(UserDTO user)
        {
            try
            {
                return Ok(_userService.UpdateUserName(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("user")]
        public ActionResult<bool> DeleteUser(int userId)
        {
            try
            {
                return Ok(_userService.DeleteUser(userId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
