using Blog.API.Models;

namespace Blog.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task CreateUserAsync(User user);

        public Task<List<User>> GetAllUsersAsync();
    }
}
