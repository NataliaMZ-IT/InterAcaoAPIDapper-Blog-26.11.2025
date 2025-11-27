using Blog.API.Models.DTOs.Category;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Interfaces
{
    public interface ICategoryController
    {
        public ActionResult HeartBeat();

        public Task<ActionResult<List<CategoryResponseDTO>>> GetAllCategoriesAsync();

        public Task<ActionResult> CreateCategoryAsync(CategoryRequestDTO category);

        public Task<IActionResult> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdate);

        public Task<IActionResult> DeleteCategoryAsync(CategoryRequestDTO category);
    }
}
