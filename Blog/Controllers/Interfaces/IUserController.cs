using Blog.API.Models;
using Blog.API.Models.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Interfaces
{
    public interface IUserController
    {
        public ActionResult HeartBeat();

        public Task<ActionResult> CreateUserAsync(UserRequestDTO user);

        public Task<ActionResult<List<UserResponseDTO>>> GetAllUsersAsync();
    }
}
