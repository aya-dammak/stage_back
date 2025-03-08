using System.Threading.Tasks;
using foodyApi.Models;
using foodyApi.Repositories;
using foodyApi.Data;
using Microsoft.EntityFrameworkCore;

namespace foodyApi.Services
{
    public class CartService : ICartService
    {
        private readonly FoodyContext _context;
        private readonly ICartRepository _cartRepository;

        public CartService(FoodyContext context, ICartRepository cartRepository)
        {
             _context = context;
            _cartRepository = cartRepository;
        }

        public async Task<Cart> GetCartAsync(int cartId) // Ajout du paramètre cartId
        {
            return await _cartRepository.GetCartAsync(cartId); // Passer cartId au repository
        }

        public async Task<Cart> CreateCartAsync(Cart cart) // Méthode pour créer un panier
        {
            return await _cartRepository.CreateCartAsync(); // Créer un panier via le repository
        }

        public async Task AddItemToCartAsync(CartItem item)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.CartId == item.CartId);
            if (cart == null)
            {
                throw new Exception("Cart not found");
            }

            // Récupérer l'article pour obtenir son prix
            var article = await _context.Articles.FindAsync(item.ArticleId);
            if (article == null)
            {
                throw new Exception("Article not found");
            }

            item.Name = article.Name;
            item.Price = article.Price; // Assurez-vous que vous avez défini le prix de l'article
            cart.CartItems.Add(item);

            // Aucune mise à jour nécessaire pour TotalPrice, car il est calculé dynamiquement
            await _context.SaveChangesAsync();
        }




        public async Task RemoveItemFromCartAsync(int articleId)
        {
            await _cartRepository.RemoveItemFromCartAsync(articleId); // Supprimer un article
        }
    }
}
