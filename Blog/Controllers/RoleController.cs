using Blog.API.Controllers.Interfaces;
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

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRoleAsync(RoleUpdateDTO roleUpdate)
        {
            var role = await _roleService.FindRoleAsync(roleUpdate.OldName);
            if (role is null)
                return NotFound();

            await _roleService.UpdateRoleAsync(role, roleUpdate.NewName);

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteRoleAsync(RoleRequestDTO role)
        {
            var roleFound = await _roleService.FindRoleAsync(role.Name);
            if (roleFound is null)
                return NotFound();

            await _roleService.DeleteRoleAsync(roleFound);

            return NoContent();
        }
    }
}
