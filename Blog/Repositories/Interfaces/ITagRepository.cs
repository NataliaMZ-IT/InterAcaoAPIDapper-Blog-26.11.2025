using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using Blog.API.Models.DTOs.Tag;

namespace Blog.API.Repositories.Interfaces
{
    public interface ITagRepository
    {
        public Task<List<TagResponseDTO>> GetAllTagAsync();

        public Task CreateTagAsync(Tag tag);

        public Task<TagFoundDTO?> FindTagAsync(string name);

        public Task UpdateTagAsync(Tag tag, int id);

        public Task DeleteTagAsync(int id);
    }
}
