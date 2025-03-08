using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;
using foodyApi.Repositories;

namespace foodyApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Utilisation du repository pour obtenir les catégories
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();  // Appel au repository
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _categoryRepository.CreateCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
