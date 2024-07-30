using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;
using foodyApi.Repositories;

namespace foodyApi.Services
{
    public class CommandeService : ICommandeService
    {
        private readonly ICommandeRepository _commandeRepository;

        public CommandeService(ICommandeRepository commandeRepository)
        {
            _commandeRepository = commandeRepository;
        }

        public async Task<IEnumerable<Commande>> GetCommandesAsync()
        {
            return await _commandeRepository.GetCommandesAsync();
        }

        public async Task<Commande> GetCommandeByIdAsync(int id)
        {
            return await _commandeRepository.GetCommandeByIdAsync(id);
        }

        public async Task AddCommandeAsync(Commande commande)
        {
            await _commandeRepository.AddCommandeAsync(commande);
        }

        public async Task UpdateCommandeAsync(Commande commande)
        {
            await _commandeRepository.UpdateCommandeAsync(commande);
        }

        public async Task DeleteCommandeAsync(int id)
        {
            await _commandeRepository.DeleteCommandeAsync(id);
        }
    }
}
