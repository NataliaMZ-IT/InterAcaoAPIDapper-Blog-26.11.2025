using Blog.API.Models;
using Blog.API.Models.DTOs.User;

namespace Blog.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task CreateUserAsync(User user);

        public Task<List<UserResponseDTO>> GetAllUsersAsync();
    }
}
