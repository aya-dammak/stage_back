using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization; // Ajoutez ceci pour JsonIgnore

namespace foodyApi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty; // URL de l'image
            
        // Ajoutez cette propriété pour la navigation inverse
        [JsonIgnore] // Ignorer la sérialisation de cette propriété pour éviter les références circulaires
        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
