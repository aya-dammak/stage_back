using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using foodyApi.Models;
using foodyApi.Services;

namespace foodyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            var articles = await _articleService.GetArticlesAsync();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _articleService.GetArticleByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPost]
        public async Task<ActionResult> PostArticle(Article article)
        {
            // Ajoutez l'article à la base de données
            await _articleService.AddArticleAsync(article);
            
            // Charger la catégorie associée
            await _articleService.LoadCategoryAsync(article);

            // Retournez l'article avec la catégorie incluse
            return CreatedAtAction(nameof(GetArticle), new { id = article.ArticleId }, article);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, Article article)
        {
            if (id != article.ArticleId)
            {
                return BadRequest();
            }

            await _articleService.UpdateArticleAsync(article);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _articleService.DeleteArticleAsync(id);
            return NoContent();
        }
    }
}
