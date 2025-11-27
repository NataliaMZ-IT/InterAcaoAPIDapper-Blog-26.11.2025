using Blog.API.Models.DTOs.Tag;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Interfaces
{
    public interface ITagController
    {
        public ActionResult HeartBeat();

        public Task<ActionResult<List<TagResponseDTO>>> GetAllTagsAsync();

        public Task<ActionResult> CreateTagAsync(TagRequestDTO tag);

        public Task<ActionResult<TagFoundDTO?>> GetTagByIdAsync(int id);

        public Task<IActionResult> UpdateTagAsync(int id, TagRequestDTO tagUpdate);

        public Task<IActionResult> DeleteTagAsync(int id);
    }
}
