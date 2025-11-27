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

        public async Task<CategoryFoundDTO?> FindCategoryAsync(string name)
        {
            var category = await _categoryRepository.FindCategoryAsync(name);

            if (category is null)
                return null;

            return category;
        }

        public async Task UpdateCategoryAsync(CategoryFoundDTO oldCategory, string newCategory)
        {
            var updatedCategory = new Category ( newCategory,
                                                 newCategory.ToLower().Replace(" ", "-") );

            await _categoryRepository.UpdateCategoryAsync(updatedCategory, oldCategory.Id);
        }

        public async Task DeleteCategoryAsync(CategoryFoundDTO category)
        {
            await _categoryRepository.DeleteCategoryAsync(category.Id);
        }
    }
}
