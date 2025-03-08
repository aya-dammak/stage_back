using System.Collections.Generic;

namespace foodyApi.Models
{
    public class Cart
    {
        public int CartId { get; set; } // Identifiant du panier
        public List<CartItem> CartItems { get; set; } = new List<CartItem>(); // Liste des articles dans le panier

        public decimal TotalPrice => CalculateTotalPrice(); // Propriété pour calculer le prix total

        private decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (var item in CartItems)
            {
                // Vérifiez si item.Article n'est pas nul avant d'accéder à Price
                if (item.Article != null)
                {
                    total += item.Quantity * item.Article.Price; // Calcul du prix total
                }
            }
            return total;
        }
    }
}
