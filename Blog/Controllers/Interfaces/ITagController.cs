using Blog.API.Models.DTOs.Tag;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Interfaces
{
    public interface ITagController
    {
        public ActionResult HeartBeat();

        public Task<ActionResult<List<TagResponseDTO>>> GetAllTagsAsync();

        public Task<ActionResult> CreateTagAsync(TagRequestDTO tag);

        public Task<IActionResult> UpdateTagAsync(TagUpdateDTO tagUpdate);

        public Task<IActionResult> DeleteTagAsync(TagRequestDTO tag);
    }
}
