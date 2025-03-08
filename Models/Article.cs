using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace foodyApi.Models
{
    public class Article
    {
        public int ArticleId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à zéro.")]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
        
        [JsonIgnore] // Ignorer la sérialisation de cette propriété pour éviter les références circulaires
        public virtual Category? Category { get; set; }

        public Article(string? name, string? imageUrl)
        {
            Name = string.IsNullOrEmpty(name) ? string.Empty : name; // Assurez-vous d'une valeur non nulle
            ImageUrl = imageUrl;
        }

        public Article() { }
    }
}
