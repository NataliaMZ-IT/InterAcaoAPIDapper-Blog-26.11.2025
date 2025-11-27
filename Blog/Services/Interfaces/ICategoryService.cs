using Blog.API.Models;
using Blog.API.Models.DTOs.Category;

namespace Blog.API.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();

        public Task CreateCategoryAsync(CategoryRequestDTO category);

        public Task<CategoryFoundDTO?> GetCategoryByIdAsync(int id);

        public Task UpdateCategoryAsync(int id, CategoryRequestDTO categoryUpdate);

        public Task DeleteCategoryAsync(int id);
    }
}
