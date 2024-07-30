using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using foodyApi.Models;
using foodyApi.Services;

namespace foodyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandesController : ControllerBase
    {
        private readonly ICommandeService _commandeService;

        public CommandesController(ICommandeService commandeService)
        {
            _commandeService = commandeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommandes()
        {
            var commandes = await _commandeService.GetCommandesAsync();
            return Ok(commandes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Commande>> GetCommande(int id)
        {
            var commande = await _commandeService.GetCommandeByIdAsync(id);
            if (commande == null)
            {
                return NotFound();
            }
            return Ok(commande);
        }

        [HttpPost]
        public async Task<ActionResult> PostCommande(Commande commande)
        {
            await _commandeService.AddCommandeAsync(commande);
            return CreatedAtAction(nameof(GetCommande), new { id = commande.CommandeId }, commande);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommande(int id, Commande commande)
        {
            if (id != commande.CommandeId)
            {
                return BadRequest();
            }

            await _commandeService.UpdateCommandeAsync(commande);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommande(int id)
        {
            await _commandeService.DeleteCommandeAsync(id);
            return NoContent();
        }
    }
}
