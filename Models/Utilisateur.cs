namespace foodyApi.Models
{
    public class Utilisateur
    {
        public int UtilisateurId { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }

        public Utilisateur(string nom, string email, string motDePasse)
    {
        Nom = nom;
        Email = email;
        MotDePasse = motDePasse;
    }
    
    }
}
