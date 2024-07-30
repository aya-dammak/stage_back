using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;

namespace foodyApi.Services
{
    public interface ICommandeService
    {
        Task<IEnumerable<Commande>> GetCommandesAsync();
        Task<Commande> GetCommandeByIdAsync(int id);
        Task AddCommandeAsync(Commande commande);
        Task UpdateCommandeAsync(Commande commande);
        Task DeleteCommandeAsync(int id);
    }
}
