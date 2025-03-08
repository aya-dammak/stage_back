using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using foodyApi.Models;
using foodyApi.Data;

namespace foodyApi.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly FoodyContext _context;

        public CartRepository(FoodyContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartAsync(int cartId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Article)
                .FirstOrDefaultAsync(c => c.CartId == cartId);
            
            if (cart == null)
            {
                throw new KeyNotFoundException($"Cart with id {cartId} not found."); // Lève une exception si non trouvé
            }
            return cart;
        }

        public async Task AddItemToCartAsync(CartItem item)
        {
            // Ajouter l'élément au panier
            _context.CartItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemFromCartAsync(int cartItemId)
        {
            // Supprimer un élément du panier par son ID
            var item = await _context.CartItems.FindAsync(cartItemId);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cart> CreateCartAsync()
        {
            // Créer un nouveau panier
            var cart = new Cart();
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            // Mettre à jour un panier existant
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }
    }
}
