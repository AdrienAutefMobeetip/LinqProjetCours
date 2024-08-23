using LinqProject.Models;
using Microsoft.AspNetCore.Mvc;
using LinqProject.Services;

namespace LinqProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantController : ControllerBase
    {
        private readonly EtudiantService _etudiantService;

        public EtudiantController(EtudiantService etudiantService)
        {
            _etudiantService = etudiantService;
        }

        [HttpGet("recherche")]
        [ProducesResponseType(typeof(List<Etudiant>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RechercheEtudiants(string query)
        {
            var result = _etudiantService.Recherche(query);
            if (result == null || result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("triernom")]
        [ProducesResponseType(typeof(List<Etudiant>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult TrierParNom()
        {
            var result = _etudiantService.TrierParNom();
            if (result == null || result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("filtrerparage")]
        public IActionResult FiltrerParAge(int ageMinimum)
        {
            var result = _etudiantService.FiltrerParAge(ageMinimum);
            if (result == null || result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("convertjsonToxml")]
        public IActionResult ConvertJsonToXml()
        {
            _etudiantService.ConvertJsonToXml();
            return Ok("Conversion de JSON à XML faite avec succès.");
        }
    }
}
