using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using foodyApi.Data;
using foodyApi.Models;

namespace foodyApi.Repositories
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly FoodyContext _context;

        public UtilisateurRepository(FoodyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Utilisateur>> GetUtilisateursAsync()
        {
            return await _context.Utilisateurs.ToListAsync();
        }

        public async Task<Utilisateur> GetUtilisateurByIdAsync(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                throw new KeyNotFoundException($"Utilisateur with ID {id} not found.");
            }
            return utilisateur;
        }

        public async Task AddUtilisateurAsync(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Add(utilisateur);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUtilisateurAsync(Utilisateur utilisateur)
        {
            _context.Entry(utilisateur).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUtilisateurAsync(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur != null)
            {
                _context.Utilisateurs.Remove(utilisateur);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Utilisateur with ID {id} not found.");
            }
        }
    }
}
