using Blog.API.Models;
using Blog.API.Models.DTOs.Role;
using Blog.API.Repositories;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

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
            try
            {
                var newRole = new Role(role.Name,
                                       role.Name.ToLower().Replace(" ", "-"));

                await _roleRepository.CreateRoleAsync(newRole);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task<List<RoleResponseDTO>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRoleAsync();
        }

        public async Task<RoleFoundDTO?> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role is null)
                return null;

            return role;
        }

        public async Task UpdateRoleAsync(int id, RoleRequestDTO roleUpdate)
        {
            try
            {
                var roleUpdated = new Role(roleUpdate.Name,
                                           roleUpdate.Name.ToLower().Replace(" ", "-"));

                await _roleRepository.UpdateRoleAsync(roleUpdated, id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteRoleAsync(id);
        }
    }
}
