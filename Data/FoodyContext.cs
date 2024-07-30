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
        public DbSet<Article> Articles { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("server=localhost;database=foodydb;user=root;password=", new MySqlServerVersion(new Version(8, 0, 26)));
        }
    }
    }
}
