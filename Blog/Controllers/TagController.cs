using Blog.API.Controllers.Interfaces;
using Blog.API.Models.DTOs.Tag;
using Blog.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase, ITagController
    {
        private readonly TagService _tagService;

        public TagController(TagService tagService)
        {
            _tagService = tagService;
        }
        
        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Bu-dum");
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateTagAsync(TagRequestDTO tag)
        {
            await _tagService.CreateTagAsync(tag);

            return Created();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<TagResponseDTO>>> GetAllTagsAsync()
        {
            var tags = await _tagService.GetAllTagsAsync();

            return Ok(tags);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTagAsync(TagUpdateDTO tagUpdate)
        {
            var tag = await _tagService.FindTagAsync(tagUpdate.OldName);
            if (tag is null)
                return NotFound();

            await _tagService.UpdateTagAsync(tag, tagUpdate.NewName);

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteTagAsync(TagRequestDTO tag)
        {
            var tagFound = await _tagService.FindTagAsync(tag.Name);
            if (tagFound is null)
                return NotFound();

            await _tagService.DeleteTagAsync(tagFound);

            return NoContent();
        }
    }
}
