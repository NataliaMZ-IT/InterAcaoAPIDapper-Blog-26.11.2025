using Blog.API.Models.DTOs.Role;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Interfaces
{
    public interface IRoleController
    {
        public ActionResult HeartBeat();

        public Task<ActionResult<List<RoleResponseDTO>>> GetAllRolesAsync();

        public Task<ActionResult> CreateRoleAsync(RoleRequestDTO role);

        public Task<ActionResult<RoleFoundDTO?>> GetRoleByIdAsync(int id);

        public Task<IActionResult> UpdateRoleAsync(int id, RoleRequestDTO roleUpdate);

        public Task<IActionResult> DeleteRoleAsync(int id);
    }
}
