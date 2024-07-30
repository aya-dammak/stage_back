using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;
using foodyApi.Repositories;

namespace foodyApi.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepository _utilisateurRepository;

        public UtilisateurService(IUtilisateurRepository utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
        }

        public async Task<IEnumerable<Utilisateur>> GetUtilisateursAsync()
        {
            return await _utilisateurRepository.GetUtilisateursAsync();
        }

        public async Task<Utilisateur> GetUtilisateurByIdAsync(int id)
        {
            return await _utilisateurRepository.GetUtilisateurByIdAsync(id);
        }

        public async Task AddUtilisateurAsync(Utilisateur utilisateur)
        {
            await _utilisateurRepository.AddUtilisateurAsync(utilisateur);
        }

        public async Task UpdateUtilisateurAsync(Utilisateur utilisateur)
        {
            await _utilisateurRepository.UpdateUtilisateurAsync(utilisateur);
        }

        public async Task DeleteUtilisateurAsync(int id)
        {
            await _utilisateurRepository.DeleteUtilisateurAsync(id);
        }
    }
}
