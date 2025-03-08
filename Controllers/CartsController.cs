using Microsoft.AspNetCore.Mvc;
using foodyApi.Models;
using foodyApi.Services;
using System.Threading.Tasks;

namespace foodyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCart(int id)
        {
            var cart = await _cartService.GetCartAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart()
        {
            var cart = new Cart(); // Créez une nouvelle instance de Cart
            var createdCart = await _cartService.CreateCartAsync(cart); // Passez le cart à la méthode
            return CreatedAtAction(nameof(GetCart), new { id = createdCart.CartId }, createdCart);
        }

        [HttpPost("{cartId}/items")]
        public async Task<IActionResult> AddItemToCart(int cartId, [FromBody] CartItem item)
        {
            if (item == null) // Vérification si l'item est nul
            {
                return BadRequest("Item cannot be null.");
            }

            item.CartId = cartId; // Assurez-vous que l'item a le bon CartId
            await _cartService.AddItemToCartAsync(item);
            return Ok();
        }

        [HttpDelete("items/{cartItemId}")]
        public async Task<IActionResult> RemoveItemFromCart(int cartItemId)
        {
            await _cartService.RemoveItemFromCartAsync(cartItemId);
            return NoContent();
        }
    }
}
