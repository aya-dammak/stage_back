using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;

namespace foodyApi.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}
