using System.Threading.Tasks;
using foodyApi.Models;

namespace foodyApi.Services
{
    public interface ICartService
    {
        Task<Cart> GetCartAsync(int cartId); // Ajout du paramètre cartId
        Task<Cart> CreateCartAsync(Cart cart); // Ajout d'une méthode pour créer un panier
        Task AddItemToCartAsync(CartItem cartItem); // Ajouter un article au panier
        Task RemoveItemFromCartAsync(int articleId); // Supprimer un article du panier
    }
}
