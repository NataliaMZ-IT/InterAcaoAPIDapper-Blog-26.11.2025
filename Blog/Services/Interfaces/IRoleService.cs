using Blog.API.Models.DTOs.Role;

namespace Blog.API.Services.Interfaces
{
    public interface IRoleService
    {
        public Task<List<RoleResponseDTO>> GetAllRolesAsync();

        public Task CreateRoleAsync(RoleRequestDTO role);

        public Task<RoleFoundDTO?> FindRoleAsync(string name);

        public Task UpdateRoleAsync(RoleFoundDTO oldRole, string newRole);

        public Task DeleteRoleAsync(RoleFoundDTO role);
    }
}
