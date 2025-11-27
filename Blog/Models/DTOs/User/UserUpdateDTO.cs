namespace Blog.API.Models.DTOs.User
{
    public class UserUpdateDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
    }
}
