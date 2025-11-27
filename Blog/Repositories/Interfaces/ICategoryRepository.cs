using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using System.Data.Common;

namespace Blog.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();

        public Task CreateCategoryAsync(Category category);

        public Task<CategoryFoundDTO?> GetCategoryByIdAsync(int id);

        public Task UpdateCategoryAsync(Category category, int id);

        public Task DeleteCategoryAsync(int id);
    }
}
