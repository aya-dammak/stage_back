using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using foodyApi.Data;
using foodyApi.Models;

namespace foodyApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FoodyContext _context;

        public CategoryRepository(FoodyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
                .Include(c => c.Articles)  // Inclure les articles associés
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Articles)  // Inclure les articles associés
                .FirstOrDefaultAsync(c => c.CategoryId == id);
            
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with id {id} not found.");
            }
            return category;
        }

        public async Task CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
