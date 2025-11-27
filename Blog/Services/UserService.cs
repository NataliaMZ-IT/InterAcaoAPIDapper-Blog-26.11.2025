using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
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
    }
}
