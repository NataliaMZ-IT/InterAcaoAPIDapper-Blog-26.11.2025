using Blog.API.Models.DTOs.Tag;

namespace Blog.API.Services.Interfaces
{
    public interface ITagService
    {
        public Task<List<TagResponseDTO>> GetAllTagsAsync();

        public Task CreateTagAsync(TagRequestDTO tag);

        public Task<TagFoundDTO?> FindTagAsync(string name);

        public Task UpdateTagAsync(TagFoundDTO oldTag, string newTag);

        public Task DeleteTagAsync(TagFoundDTO tag);
    }
}
