using Blog.API.Controllers.Interfaces;
using Blog.API.Models;
using Blog.API.Models.DTOs.User;
using Blog.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        private readonly UserService _userService;

        public UserController(UserService userService) {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Bu-dum");
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateUserAsync(UserRequestDTO user)
        {
            try
            {
                await _userService.CreateUserAsync(user);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();

                return Ok(users);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllUserRoles")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllUserRolesAsync()
        {
            try
            {
                var userRoles = await _userService.GetAllUserRolesAsync();

                return Ok(userRoles);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<UserFoundDTO?>> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user is null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetRoles/{id}")]
        public async Task<ActionResult<UserRequestDTO>> GetUserRolesByIdAsynce(int id)
        {
            try
            {
                var userRole = await _userService.GetUserRolesById(id);
                if (userRole is null)
                    return NotFound();

                return Ok(userRole);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, UserUpdateDTO userUpdate)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user is null)
                    return NotFound();

                await _userService.UpdateUserAsync(user, userUpdate);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user is null)
                    return NotFound();

                await _userService.DeleteUserAsync(user.Id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
