using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using foodyApi.Data;
using foodyApi.Models;

namespace foodyApi.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly FoodyContext _context;

        public CartItemRepository(FoodyContext context)
        {
            _context = context;
        }

        // Obtenir tous les CartItems
        public async Task<IEnumerable<CartItem>> GetCartItemsAsync()
        {
            return await _context.CartItems.Include(c => c.Article).ToListAsync();
        }

        // Obtenir un CartItem par son ID
        public async Task<CartItem?> GetCartItemByIdAsync(int id) // Retourne un CartItem nullable
        {
            return await _context.CartItems
                .Include(c => c.Article)  // Inclure l'Article lié
                .FirstOrDefaultAsync(c => c.CartItemId == id);  // Rechercher par CartItemId
        }

        // Ajouter un CartItem
        public async Task AddCartItemAsync(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
        }

        // Mettre à jour un CartItem
        public async Task UpdateCartItemAsync(CartItem cartItem)
        {
            _context.Entry(cartItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Supprimer un CartItem
        public async Task DeleteCartItemAsync(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"CartItem with ID {id} not found."); // Gestion de l'absence d'élément
            }
        }
    }
}
