using Blog.API.Models;
using Blog.API.Models.DTOs.Role;
using Blog.API.Repositories;
using Blog.API.Services.Interfaces;

namespace Blog.API.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task CreateRoleAsync(RoleRequestDTO role)
        {
            var newRole = new Role(role.Name,
                                   role.Name.ToLower().Replace(" ", "-"));

            await _roleRepository.CreateRoleAsync(newRole);
        }

        public async Task<List<RoleResponseDTO>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRoleAsync();
        }

        public async Task<RoleFoundDTO?> FindRoleAsync(string name)
        {
            var role = await _roleRepository.FindRoleAsync(name);
            if (role is null)
                return null;

            return role;
        }

        public async Task UpdateRoleAsync(RoleFoundDTO oldRole, string newRole)
        {
            var roleUpdated = new Role(newRole,
                                       newRole.ToLower().Replace(" ", "-"));

            await _roleRepository.UpdateRoleAsync(roleUpdated, oldRole.Id);
        }

        public async Task DeleteRoleAsync(RoleFoundDTO role)
        {
            await _roleRepository.DeleteRoleAsync(role.Id);
        }
    }
}
