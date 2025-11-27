using Blog.API.Models.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Interfaces
{
    public interface IUserController
    {
        public Task<ActionResult> CreateUserAsync(UserRequestDTO user);
    }
}
