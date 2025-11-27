using Blog.API.Models.DTOs.Role;

namespace Blog.API.Services.Interfaces
{
    public interface IRoleService
    {
        public Task<List<RoleResponseDTO>> GetAllRolesAsync();

        public Task CreateRoleAsync(RoleRequestDTO role);

        public Task<RoleFoundDTO?> GetRoleByIdAsync(int id);

        public Task UpdateRoleAsync(int id, RoleRequestDTO roleUpdate);

        public Task DeleteRoleAsync(int id);
    }
}
