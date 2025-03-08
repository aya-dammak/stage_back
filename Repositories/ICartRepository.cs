using System.Threading.Tasks;
using foodyApi.Models;

namespace foodyApi.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartAsync(int cartId);
        Task<Cart> CreateCartAsync();
        Task AddItemToCartAsync(CartItem cartItem);
        Task UpdateCartAsync(Cart cart);
        Task RemoveItemFromCartAsync(int cartItemId);
        
    }
}
