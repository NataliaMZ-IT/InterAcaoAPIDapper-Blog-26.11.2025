using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using Blog.API.Repositories;
using Blog.API.Services.Interfaces;

namespace Blog.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryrepository)
        {
            _categoryRepository = categoryrepository;
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task CreateCategoryAsync(CategoryRequestDTO category)
        {
            var newCategory = new Category ( category.Name, 
                                             category.Name.ToLower().Replace(" ", "-") );

            await _categoryRepository.CreateCategoryAsync(newCategory);
        }

        public async Task<CategoryFoundDTO?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category is null)
                return null;

            return category;
        }

        public async Task UpdateCategoryAsync(int id, CategoryRequestDTO categoryUpdate)
        {
            var updatedCategory = new Category ( categoryUpdate.Name,
                                                 categoryUpdate.Name.ToLower().Replace(" ", "-") );

            await _categoryRepository.UpdateCategoryAsync(updatedCategory, id);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
