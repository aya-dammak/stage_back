using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;

namespace foodyApi.Services
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItem>> GetCartItemsAsync();
        Task<CartItem> GetCartItemByIdAsync(int id);
        Task AddCartItemAsync(CartItem cartItem);
        Task UpdateCartItemAsync(CartItem cartItem);
        Task DeleteCartItemAsync(int id);
    }
}
