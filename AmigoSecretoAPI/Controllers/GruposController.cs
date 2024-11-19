using AmigoSecretoAPI.Data.Dto;
using AmigoSecretoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmigoSecretoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly GrupoService _service;

        public GruposController(GrupoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarGrupo([FromBody] string nome)
        {
            var grupo = await _service.CriarGrupoAsync(nome);
            return CreatedAtAction(nameof(CriarGrupo), new { id = grupo.Id }, grupo);
        }

        [HttpPost("{idGrupo}/participantes")]
        public async Task<IActionResult> AdicionarParticipante(int idGrupo, [FromBody] ParticipanteDto participante)
        {
            await _service.AdicionarParticipanteAsync(idGrupo, participante);
            return NoContent();
        }

        [HttpPost("{idGrupo}/matches")]
        public async Task<IActionResult> GerarMatches(int idGrupo)
        {
            await _service.GerarMatchesAsync(idGrupo);
            return Ok("Matches gerados com sucesso.");
        }

        [HttpGet("{idGrupo}/participantes/{idParticipante}/match")]
        public async Task<IActionResult> ObterPresenteado(int idGrupo, int idParticipante)
        {
            var presenteado = await _service.ObterPresenteadoAsync(idGrupo, idParticipante);
            return Ok(presenteado);
        }

    }
}
