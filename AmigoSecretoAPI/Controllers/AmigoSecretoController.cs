using AmigoSecreto.domain.Entidades;
using AmigoSecreto.services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmigoSecretoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmigoSecretoController : ControllerBase
    {
        private readonly AmigoSecretoServices _service;

        public AmigoSecretoController(AmigoSecretoServices service)
        {
            _service = service;
        }

        [HttpPost("groups")]
        public async Task<ActionResult<Group>> CreateGroup([FromBody] Group group)
        {
            var createdGroup = await _service.CreateGroup(group);
            return CreatedAtAction(nameof(CreateGroup), new { Id = createdGroup.Id }, createdGroup);
        }


        [HttpPost("groups/{groupId}/participantes")]
        public async Task<ActionResult<Participante>> AddParticipante(int groupId, [FromBody] Participante participante)
        {
            var part
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
