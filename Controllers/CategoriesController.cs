using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using foodyApi.Models;
using foodyApi.Services;

namespace foodyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Utilisation du service au lieu de _context
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryService.GetCategoriesAsync();  // Appel du service
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            await _categoryService.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryId }, category); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId) return BadRequest();
            await _categoryService.UpdateCategoryAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
