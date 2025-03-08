using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using foodyApi.Data;
using foodyApi.Repositories;
using foodyApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Ajouter le contexte de base de données
builder.Services.AddDbContext<FoodyContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
    new MySqlServerVersion(new Version(8, 0, 26)))
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
);

// Enregistrer les repositories et services
builder.Services.AddScoped<ICommandeRepository, CommandeRepository>();
builder.Services.AddScoped<ICommandeService, CommandeService>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<ICartItemService, CartItemService>();

// Ajouter les services de contrôleurs avec configuration JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; // Ignorer les cycles de référence
});

// Configurer l'application
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
