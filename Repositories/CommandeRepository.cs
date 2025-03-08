using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using foodyApi.Models;
using foodyApi.Data;

namespace foodyApi.Repositories
{
    public class CommandeRepository : ICommandeRepository
    {
        private readonly FoodyContext _context;

        public CommandeRepository(FoodyContext context)
        {
            _context = context;
        }

        public async Task<List<Commande>> GetAllCommandesAsync() // Changez ici en List
        {
            return await _context.Commandes.ToListAsync();
        }

        public async Task<Commande> GetCommandeByIdAsync(int commandeId)
        {
            var commande = await _context.Commandes.FindAsync(commandeId);
            return commande ?? throw new KeyNotFoundException($"Commande with ID {commandeId} not found.");
        }

        public async Task<Commande> CreateCommandeAsync(Commande commande)
        {
            _context.Commandes.Add(commande);
            await _context.SaveChangesAsync();
            return commande;
        }

        public async Task<Commande> UpdateCommandeAsync(Commande commande) // Changez ici en Commande
        {
            var existingCommande = await _context.Commandes.FindAsync(commande.CommandeId);
            if (existingCommande != null)
            {
                existingCommande.Nom = commande.Nom;
                existingCommande.Email = commande.Email;
                existingCommande.Adresse = commande.Adresse;
                existingCommande.Telephone = commande.Telephone;
                existingCommande.DetailsCommande = commande.DetailsCommande;

                await _context.SaveChangesAsync();
                return existingCommande; // Retourner la commande mise à jour
            }

            throw new KeyNotFoundException($"Commande with ID {commande.CommandeId} not found.");
        }

        public async Task<bool> DeleteCommandeAsync(int commandeId)
        {
            var commande = await _context.Commandes.FindAsync(commandeId);
            if (commande != null)
            {
                _context.Commandes.Remove(commande);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
