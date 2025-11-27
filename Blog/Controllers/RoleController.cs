using Blog.API.Controllers.Interfaces;
using Blog.API.Models.DTOs.Category;
using Blog.API.Models.DTOs.Role;
using Blog.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase, IRoleController
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Bu-dum");
        }
        [HttpPost("Create")]
        public async Task<ActionResult> CreateRoleAsync(RoleRequestDTO role)
        {
            await _roleService.CreateRoleAsync(role);

            return Created();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RoleResponseDTO>>> GetAllRolesAsync()
        {
            var roles = await _roleService.GetAllRolesAsync();

            return Ok(roles);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<RoleFoundDTO?>> GetRoleByIdAsync(int id)
        {
            try
            {
                var role = await _roleService.GetRoleByIdAsync(id);
                if (role is null)
                    return NotFound();

                return Ok(role);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateRoleAsync(int id, RoleRequestDTO roleUpdate)
        {
            try
            {
                var role = await _roleService.GetRoleByIdAsync(id);
                if (role is null)
                    return NotFound();

                await _roleService.UpdateRoleAsync(role.Id, roleUpdate);

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteRoleAsync(int id)
        {
            try
            {
                var roleFound = await _roleService.GetRoleByIdAsync(id);
                if (roleFound is null)
                    return NotFound();

                await _roleService.DeleteRoleAsync(roleFound.Id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
