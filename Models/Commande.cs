using System;

namespace foodyApi.Models
{
    public class Commande
    {
        public int CommandeId { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string DetailsCommande { get; set; } 
        public DateTime DateCommande { get; set; } = DateTime.Now;

        public Commande(string nom, string email, string adresse, string telephone, string detailsCommande)
    {
        Nom = nom;
        Email = email;
        Adresse = adresse;
        Telephone = telephone;
        DetailsCommande = detailsCommande;
    }

    }
}
