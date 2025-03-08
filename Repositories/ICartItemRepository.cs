using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;

namespace foodyApi.Repositories
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> GetCartItemsAsync();
        Task<CartItem?> GetCartItemByIdAsync(int id);
        Task AddCartItemAsync(CartItem cartItem);
        Task UpdateCartItemAsync(CartItem cartItem);
        Task DeleteCartItemAsync(int id);
    }
}
