using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using foodyApi.Data;
using foodyApi.Models;

namespace foodyApi.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly FoodyContext _context;

        public ArticleRepository(FoodyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                throw new KeyNotFoundException($"Article with ID {id} not found.");
            }
            return article;
        }

        public async Task AddArticleAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateArticleAsync(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArticleAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Article with ID {id} not found.");
            }
        }
    }
}
