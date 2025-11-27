using Blog.API.Models;
using Blog.API.Models.DTOs.Tag;
using Blog.API.Repositories;
using Blog.API.Services.Interfaces;

namespace Blog.API.Services
{
    public class TagService : ITagService
    {
        private readonly TagRepository _tagRepository;

        public TagService(TagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task CreateTagAsync(TagRequestDTO tag)
        {
            var newTag = new Tag(tag.Name,
                                 tag.Name.ToLower().Replace(" ", "-"));

            await _tagRepository.CreateTagAsync(newTag);
        }

        public async Task<List<TagResponseDTO>> GetAllTagsAsync()
        {
            return await _tagRepository.GetAllTagAsync();
        }

        public async Task<TagFoundDTO?> FindTagAsync(string name)
        {
            var tag = await _tagRepository.FindTagAsync(name);
            if (tag is null)
                return null;

            return tag;
        }

        public async Task UpdateTagAsync(TagFoundDTO oldTag, string newTag)
        {
            var updatedTag = new Tag(newTag,
                                     newTag.ToLower().Replace(" ", "-"));

            await _tagRepository.UpdateTagAsync(updatedTag, oldTag.Id);
        }

        public async Task DeleteTagAsync(TagFoundDTO tag)
        {
            await _tagRepository.DeleteTagAsync(tag.Id);
        }
    }
}
