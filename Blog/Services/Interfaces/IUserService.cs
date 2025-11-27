using Blog.API.Models;
using Blog.API.Models.DTOs.User;

namespace Blog.API.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateUserAsync(UserRequestDTO user);

        public Task<List<UserResponseDTO>> GetAllUsersAsync();
    }
}
