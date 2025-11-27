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

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<TagFoundDTO?>> GetTagByIdAsync(int id)
        {
            try
            {
                var tag = await _tagService.GetTagByIdAsync(id);
                if (tag is null)
                    return NotFound();

                return Ok(tag);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateTagAsync(int id, TagRequestDTO tagUpdate)
        {
            try
            {
                var tag = await _tagService.GetTagByIdAsync(id);
                if (tag is null)
                    return NotFound();

                await _tagService.UpdateTagAsync(tag.Id, tagUpdate);

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTagAsync(int id)
        {
            var tagFound = await _tagService.GetTagByIdAsync(id);
            if (tagFound is null)
                return NotFound();

            await _tagService.DeleteTagAsync(tagFound.Id);

            return NoContent();
        }
    }
}
