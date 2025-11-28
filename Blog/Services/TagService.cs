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

        public async Task<TagFoundDTO?> GetTagByIdAsync(int id)
        {
            var tag = await _tagRepository.GetTagByIdAsync(id) ?? null;

            return tag;
        }

        public async Task UpdateTagAsync(int id, TagRequestDTO tagUpdate)
        {
            var updatedTag = new Tag(tagUpdate.Name,
                                     tagUpdate.Name.ToLower().Replace(" ", "-"));

            await _tagRepository.UpdateTagAsync(updatedTag, id);
        }

        public async Task DeleteTagAsync(int id)
        {
            try
            {
                await _tagRepository.DeleteTagAsync(id);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.StackTrace);
            }
        }
    }
}
