using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;

namespace foodyApi.Services
{
    public interface ICommandeService
    {
        Task<Commande> CreateCommandeAsync(Commande commande);
        Task<List<Commande>> GetAllCommandesAsync();
        Task<Commande> GetCommandeByIdAsync(int commandeId);
        Task<Commande> UpdateCommandeAsync(Commande commande);
        Task<bool> DeleteCommandeAsync(int commandeId);
    }
}
