using System.Collections.Generic;

namespace foodyApi.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }  // ID du CartItem
        public int ArticleId { get; set; }    // ID de l'article
        public int CartId { get; set; }       // ID du panier
        public int Quantity { get; set; }      // Quantité de l'article
        public string? Name { get; set; }      // Nom de l'article (nullable)
        public decimal Price { get; set; }
        
        public virtual Article? Article { get; set; } // Référence à l'article (nullable)
    }
}
