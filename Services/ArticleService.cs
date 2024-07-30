using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;
using foodyApi.Repositories;

namespace foodyApi.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            return await _articleRepository.GetArticlesAsync();
        }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _articleRepository.GetArticleByIdAsync(id);
        }

        public async Task AddArticleAsync(Article article)
        {
            await _articleRepository.AddArticleAsync(article);
        }

        public async Task UpdateArticleAsync(Article article)
        {
            await _articleRepository.UpdateArticleAsync(article);
        }

        public async Task DeleteArticleAsync(int id)
        {
            await _articleRepository.DeleteArticleAsync(id);
        }
    }
}
