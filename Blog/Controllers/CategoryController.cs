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

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<CategoryFoundDTO?>> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category is null)
                    return NotFound();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateCategoryAsync(CategoryRequestDTO category)
        {
            await _categoryService.CreateCategoryAsync(category);

            return Created();
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(int id, CategoryRequestDTO categoryUpdate)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);

                if (category is null)
                    return NotFound();

                await _categoryService.UpdateCategoryAsync(category.Id, categoryUpdate);

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            try
            {
                var categoryFound = await _categoryService.GetCategoryByIdAsync(id);

                if (categoryFound is null)
                    return NotFound();

                await _categoryService.DeleteCategoryAsync(categoryFound.Id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
