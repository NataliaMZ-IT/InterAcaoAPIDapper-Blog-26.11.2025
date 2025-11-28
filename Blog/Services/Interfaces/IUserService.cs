using Blog.API.Models;
using Blog.API.Models.DTOs.User;

namespace Blog.API.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateUserAsync(UserRequestDTO user);

        public Task<List<UserResponseDTO>> GetAllUsersAsync();

        public Task<List<UserResponseDTO>> GetAllUserRolesAsync();

        public Task<UserFoundDTO?> GetUserByIdAsync(int id);

        public Task<UserResponseDTO> GetUserRolesById(int id);

        public Task UpdateUserAsync(UserFoundDTO user, UserUpdateDTO userUpdate);

        public Task DeleteUserAsync(int id);
    }
}
