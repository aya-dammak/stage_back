using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;

namespace foodyApi.Services
{
    public interface IUtilisateurService
    {
        Task<IEnumerable<Utilisateur>> GetUtilisateursAsync();
        Task<Utilisateur> GetUtilisateurByIdAsync(int id);
        Task AddUtilisateurAsync(Utilisateur utilisateur);
        Task UpdateUtilisateurAsync(Utilisateur utilisateur);
        Task DeleteUtilisateurAsync(int id);
    }
}
