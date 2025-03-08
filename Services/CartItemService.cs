using System.Collections.Generic;
using System.Threading.Tasks;
using foodyApi.Models;
using foodyApi.Repositories;

namespace foodyApi.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        // Récupérer tous les CartItems
        public async Task<IEnumerable<CartItem>> GetCartItemsAsync()
        {
            return await _cartItemRepository.GetCartItemsAsync();
        }

        // Récupérer un CartItem par son ID
        public async Task<CartItem> GetCartItemByIdAsync(int id)
        {
            var cartItem = await _cartItemRepository.GetCartItemByIdAsync(id);
            if (cartItem == null)
            {
                throw new KeyNotFoundException($"CartItem with id {id} not found."); // Lève une exception si non trouvé
            }
            return cartItem;
        }

        // Ajouter un CartItem
        public async Task AddCartItemAsync(CartItem cartItem)
        {
            await _cartItemRepository.AddCartItemAsync(cartItem);
        }

        // Mettre à jour un CartItem
        public async Task UpdateCartItemAsync(CartItem cartItem)
        {
            await _cartItemRepository.UpdateCartItemAsync(cartItem);
        }

        // Supprimer un CartItem
        public async Task DeleteCartItemAsync(int id)
        {
            await _cartItemRepository.DeleteCartItemAsync(id);
        }
    }
}
