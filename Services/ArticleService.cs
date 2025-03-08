using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;
using foodyApi.Repositories;
using Microsoft.EntityFrameworkCore;

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

        // Nouvelle méthode pour charger la catégorie associée
        public async Task LoadCategoryAsync(Article article)
        {
            // Utilisez le repository ou le contexte pour charger la catégorie
            await _articleRepository.LoadCategoryAsync(article);
        }
    }
}
