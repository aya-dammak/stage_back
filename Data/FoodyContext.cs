using Microsoft.EntityFrameworkCore;
using foodyApi.Models;

namespace foodyApi.Data
{
    public class FoodyContext : DbContext
    {
        public FoodyContext(DbContextOptions<FoodyContext> options) : base(options)
        {
        }

        public DbSet<Commande> Commandes { get; set; }
        public DbSet<CommandeItem> CommandeItems { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommandeItem>()
                .HasKey(ci => ci.CommandeItemId);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Articles) // Ajouter la navigation inverse ici
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Optionnel, pour la suppression en cascade

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=foodydb;user=root;password=", 
                    new MySqlServerVersion(new Version(8, 0, 26)));
            }
        }
    }
}
