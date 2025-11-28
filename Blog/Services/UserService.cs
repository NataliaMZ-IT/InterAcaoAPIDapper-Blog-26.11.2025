using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.User;
using Blog.API.Repositories;
using Blog.API.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace Blog.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(UserRequestDTO user)
        {
            var newUser = new User(user.Name, user.Email, 
                                   user.PasswordHash,
                                   user.Bio, user.Image, 
                                   user.Name.ToLower().Replace(" ", "-")
                                   );

            await _userRepository.CreateUserAsync(newUser);
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<UserFoundDTO?> GetUserByIdAsync(int id)
        {
            return (await _userRepository.GetUserByIdAsync(id)) ?? null;
        }

        public async Task UpdateUserAsync(UserFoundDTO user, UserUpdateDTO userUpdate)
        {
            var updatedUser = new User(userUpdate.Name ?? user.Name,
                                       userUpdate.Email ?? user.Email,
                                       userUpdate.PasswordHash ?? user.PasswordHash,
                                       userUpdate.Bio ?? user.Bio,
                                       userUpdate.Image ?? user.Image,
                                       userUpdate.Name is null ? user.Slug : userUpdate.Name.ToLower().Replace(" ", "-")
                                       );

            await _userRepository.UpdateUserAsync(updatedUser, user.Id);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<List<UserResponseDTO>> GetAllUserRolesAsync()
        {
            try
            {
                return await _userRepository.GetAllUserRolesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task<UserResponseDTO> GetUserRolesById(int id)
        {
            try
            {
                return await _userRepository.GetUserRolesByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }
    }
}
