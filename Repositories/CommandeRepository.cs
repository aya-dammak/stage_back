using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using foodyApi.Data;
using foodyApi.Models;

namespace foodyApi.Repositories
{
    public class CommandeRepository : ICommandeRepository
    {
        private readonly FoodyContext _context;

        public CommandeRepository(FoodyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Commande>> GetCommandesAsync()
        {
            return await _context.Commandes.ToListAsync();
        }

        public async Task<Commande> GetCommandeByIdAsync(int id)
        {
            var commande = await _context.Commandes.FindAsync(id);
            if (commande == null)
            {
                throw new KeyNotFoundException($"Commande with ID {id} not found.");
            }
            return commande;
        }

        public async Task AddCommandeAsync(Commande commande)
        {
            _context.Commandes.Add(commande);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCommandeAsync(Commande commande)
        {
            _context.Entry(commande).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommandeAsync(int id)
        {
            var commande = await _context.Commandes.FindAsync(id);
            if (commande != null)
            {
                _context.Commandes.Remove(commande);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Commande with ID {id} not found.");
            }
        }
    }
}
