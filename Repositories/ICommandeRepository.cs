using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;

namespace foodyApi.Repositories
{
    public interface ICommandeRepository
    {
        Task<List<Commande>> GetAllCommandesAsync(); // Changez ici en List
        Task<Commande> GetCommandeByIdAsync(int commandeId);
        Task<Commande> CreateCommandeAsync(Commande commande);
        Task<Commande> UpdateCommandeAsync(Commande commande); // Changez ici en Commande
        Task<bool> DeleteCommandeAsync(int commandeId);
    }
}
