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

        public async Task<Commande> CreateCommandeAsync(Commande commande)
        {
            return await _commandeRepository.CreateCommandeAsync(commande);
        }

        public async Task<List<Commande>> GetAllCommandesAsync()
        {
            return await _commandeRepository.GetAllCommandesAsync();
        }

        public async Task<Commande> GetCommandeByIdAsync(int commandeId)
        {
            return await _commandeRepository.GetCommandeByIdAsync(commandeId);
        }

        public async Task<Commande> UpdateCommandeAsync(Commande commande)
        {
            return await _commandeRepository.UpdateCommandeAsync(commande);
        }

        public async Task<bool> DeleteCommandeAsync(int commandeId)
        {
            return await _commandeRepository.DeleteCommandeAsync(commandeId);
        }
    }
}
