using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;

namespace foodyApi.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticlesAsync();
        Task<Article> GetArticleByIdAsync(int id);
        Task AddArticleAsync(Article article);
        Task UpdateArticleAsync(Article article);
        Task DeleteArticleAsync(int id);
    }
}
