using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using foodyApi.Models;
using foodyApi.Services;

namespace foodyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurService;

        public UtilisateursController(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            var utilisateurs = await _utilisateurService.GetUtilisateursAsync();
            return Ok(utilisateurs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
        {
            var utilisateur = await _utilisateurService.GetUtilisateurByIdAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return Ok(utilisateur);
        }

        [HttpPost]
        public async Task<ActionResult> PostUtilisateur(Utilisateur utilisateur)
        {
            await _utilisateurService.AddUtilisateurAsync(utilisateur);
            return CreatedAtAction(nameof(GetUtilisateur), new { id = utilisateur.UtilisateurId }, utilisateur);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.UtilisateurId)
            {
                return BadRequest();
            }

            await _utilisateurService.UpdateUtilisateurAsync(utilisateur);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            await _utilisateurService.DeleteUtilisateurAsync(id);
            return NoContent();
        }
    }
}
