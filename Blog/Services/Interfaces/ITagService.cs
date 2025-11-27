using Blog.API.Models.DTOs.Tag;

namespace Blog.API.Services.Interfaces
{
    public interface ITagService
    {
        public Task<List<TagResponseDTO>> GetAllTagsAsync();

        public Task CreateTagAsync(TagRequestDTO tag);

        public Task<TagFoundDTO?> GetTagByIdAsync(int id);

        public Task UpdateTagAsync(int id, TagRequestDTO tagUpdate);

        public Task DeleteTagAsync(int id);
    }
}
