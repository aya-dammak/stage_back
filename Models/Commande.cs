using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace foodyApi.Models
{
    public class Commande
    {
        [Key]
        public int CommandeId { get; set; }

        public string Nom { get; set; } = string.Empty; // Initialisé à une chaîne vide
        public string Email { get; set; } = string.Empty; // Initialisé à une chaîne vide
        public string Adresse { get; set; } = string.Empty; // Initialisé à une chaîne vide
        public string Telephone { get; set; } = string.Empty; // Initialisé à une chaîne vide
        
        public DateTime DateCommande { get; set; } = DateTime.Now;  // Définit la date actuelle lors de la création
        
        public List<CommandeItem> DetailsCommande { get; set; } = new List<CommandeItem>(); // Initialisé à une liste vide
        
    }

    public class CommandeItem
    {
        [Key] // Indique que cette propriété est la clé primaire
        public int CommandeItemId { get; set; }
        public int CommandeId { get; set; }
        public Commande? Commande { get; set; }  // Assure la navigation entre Commande et CommandeItem

        public int ArticleId { get; set; }
        public Article? Article { get; set; }  // Assure la navigation entre Article et CommandeItem

        public int Quantity { get; set; }
    }
}
