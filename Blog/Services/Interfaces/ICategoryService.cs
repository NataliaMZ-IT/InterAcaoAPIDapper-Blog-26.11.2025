using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();

        public Task CreateCategoryAsync(CategoryRequestDTO category);

        public Task<CategoryFoundDTO?> FindCategoryAsync(string name);

        public Task UpdateCategoryAsync(CategoryFoundDTO oldCategory, string newCategory);

        public Task DeleteCategoryAsync(CategoryFoundDTO category);
    }
}
