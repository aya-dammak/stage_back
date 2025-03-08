using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using foodyApi.Models;
using foodyApi.Services;

namespace foodyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemsController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        // Récupérer tous les CartItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            var cartItems = await _cartItemService.GetCartItemsAsync();
            return Ok(cartItems);
        }

        // Ajouter un CartItem
        [HttpPost]
        public async Task<ActionResult> AddCartItem(CartItem cartItem)
        {
            await _cartItemService.AddCartItemAsync(cartItem);
            return CreatedAtAction(nameof(GetCartItems), new { id = cartItem.CartItemId }, cartItem);  // Utilisation de CartItemId au lieu de Id
        }

        // Mettre à jour un CartItem
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, CartItem cartItem)
        {
            if (id != cartItem.CartItemId)  // Utilisation de CartItemId au lieu de Id
            {
                return BadRequest();
            }

            await _cartItemService.UpdateCartItemAsync(cartItem);
            return NoContent();
        }

        // Supprimer un CartItem
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            await _cartItemService.DeleteCartItemAsync(id);
            return NoContent();
        }
    }
}
