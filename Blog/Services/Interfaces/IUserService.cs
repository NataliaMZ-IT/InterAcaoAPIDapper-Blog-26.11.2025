using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateUserAsync(UserRequestDTO user);
    }
}
