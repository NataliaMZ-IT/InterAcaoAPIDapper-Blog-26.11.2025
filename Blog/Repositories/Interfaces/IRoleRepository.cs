using Blog.API.Models;
using Blog.API.Models.DTOs.Role;
using Blog.API.Models.DTOs.Tag;

namespace Blog.API.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        public Task<List<RoleResponseDTO>> GetAllRoleAsync();

        public Task CreateRoleAsync(Role role);

        public Task<RoleFoundDTO?> GetRoleByIdAsync(int id);

        public Task UpdateRoleAsync(Role role, int id);

        public Task DeleteRoleAsync(int id);
    }
}
