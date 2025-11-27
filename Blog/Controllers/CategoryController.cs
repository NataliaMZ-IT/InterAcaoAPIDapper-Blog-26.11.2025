using Blog.API.Controllers.Interfaces;
using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using Blog.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService service)
        {
            _categoryService = service;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Bu-dum");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CategoryResponseDTO>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            return Ok(categories);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateCategoryAsync(CategoryRequestDTO category)
        {
            await _categoryService.CreateCategoryAsync(category);

            return Created();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdate)
        {
            var category = await _categoryService.FindCategoryAsync(categoryUpdate.OldName);

            if (category is null)
                return NotFound();

            await _categoryService.UpdateCategoryAsync(category, categoryUpdate.NewName);

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCategoryAsync(CategoryRequestDTO category)
        {
            var categoryFound = await _categoryService.FindCategoryAsync(category.Name);

            if (categoryFound is null)
                return NotFound();

            await _categoryService.DeleteCategoryAsync(categoryFound);

            return NoContent();
        }
    }
}
