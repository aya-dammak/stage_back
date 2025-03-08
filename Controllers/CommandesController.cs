using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foodyApi.Models;
using foodyApi.Services;

namespace foodyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandesController : ControllerBase
    {
        private readonly ICommandeService _commandeService;
        private readonly IArticleService _articleService;

        public CommandesController(ICommandeService commandeService, IArticleService articleService)
        {
            _commandeService = commandeService;
            _articleService = articleService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCommande([FromBody] Commande commande)
        {
            if (commande == null)
            {
                return BadRequest();
            }

            // Ajouter la date de la commande
            commande.DateCommande = DateTime.Now;

            // Récupérer les informations sur les articles et catégories pour chaque CommandeItem
            foreach (var item in commande.DetailsCommande)
            {
                var article = await _articleService.GetArticleByIdAsync(item.ArticleId);
                if (article == null)
                {
                    return BadRequest($"Article avec l'ID {item.ArticleId} non trouvé.");
                }
                item.Article = article;
            }

            var createdCommande = await _commandeService.CreateCommandeAsync(commande);
            if (createdCommande == null)
            {
                return StatusCode(500, "Une erreur est survenue lors de la création de la commande.");
            }

            // Retourner la commande avec tous les détails
            var result = new
            {
                createdCommande.CommandeId,
                createdCommande.Nom,
                createdCommande.Email,
                createdCommande.Adresse,
                createdCommande.Telephone,
                DetailsCommande = createdCommande.DetailsCommande.Select(item => new
                {
                    item.CommandeItemId,
                    item.ArticleId,
                    item.Quantity,
                    Article = new
                    {
                        ArticleName = item.Article?.Name ?? "Unknown", // Nom explicite pour le membre ArticleName
                        ArticlePrice = item.Article?.Price ?? 0, // Nom explicite pour le membre ArticlePrice
                        CategoryName = item.Article?.Category?.Name ?? "No Category" // Nom explicite pour le membre CategoryName
                    }
                }),
                createdCommande.DateCommande
            };

            return Ok(result);
        }


        [HttpGet]
        public async Task<ActionResult<List<Commande>>> GetAllCommandes()
        {
            var commandes = await _commandeService.GetAllCommandesAsync();
            return Ok(commandes);
        }

        [HttpGet("{commandeId}")]
        public async Task<ActionResult<Commande>> GetCommandeById(int commandeId)
        {
            var commande = await _commandeService.GetCommandeByIdAsync(commandeId);
            if (commande == null)
            {
                return NotFound();
            }
            return Ok(commande);
        }

        [HttpPut("{commandeId}")]
        public async Task<ActionResult<Commande>> UpdateCommande(int commandeId, [FromBody] Commande commande)
        {
            if (commandeId != commande.CommandeId)
            {
                return BadRequest();
            }

            var updatedCommande = await _commandeService.UpdateCommandeAsync(commande);
            if (updatedCommande == null)
            {
                return NotFound();
            }
            return Ok(updatedCommande);
        }

        [HttpDelete("{commandeId}")]
        public async Task<ActionResult> DeleteCommande(int commandeId)
        {
            var result = await _commandeService.DeleteCommandeAsync(commandeId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
