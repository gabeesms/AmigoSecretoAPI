using AmigoSecretoAPI.Data.Dto;
using AmigoSecretoAPI.Repository;
using System.Text.RegularExpressions;

namespace AmigoSecretoAPI.Services
{
    public class GrupoService
    {
        private readonly GrupoRepository _repository;

        public GrupoService(GrupoRepository repository)
        {
            _repository = repository;
        }

        public async Task<GrupoDto> CriarGrupoAsync(string nome)
        {
            var grupo = new GrupoDto { Nome = nome };
            await _repository.AddGrupoAsync(grupo);
            return grupo;
        }

        public async Task AdicionarParticipanteAsync(int idGrupo, ParticipanteDto participante)
        {
            var grupo = await _repository.GetGrupoAsync(idGrupo) ?? throw new Exception("Grupo não encontrado.");
            grupo.Participantes.Add(participante);
            await _repository.UpdateGrupoAsync(grupo);
        }

        public async Task GerarMatchesAsync(int idGrupo)
        {
            var grupo = await _repository.GetGrupoAsync(idGrupo) ?? throw new Exception("Grupo não encontrado.");
            if (grupo.Participantes.Count < 2) throw new Exception("É necessário pelo menos 2 participantes.");

            var ids = grupo.Participantes.Select(p => p.Id).ToList();
            var shuffled = ids.OrderBy(_ => Guid.NewGuid()).ToList();

            for (int i = 0; i < ids.Count; i++)
            {
                grupo.Matches[ids[i]] = shuffled[(i + 1) % ids.Count];
            }

            await _repository.UpdateGrupoAsync(grupo);
        }

        public async Task<ParticipanteDto> ObterPresenteadoAsync(int idGrupo, int idParticipante)
        {
            var grupo = await _repository.GetGrupoAsync(idGrupo) ?? throw new Exception("Grupo não encontrado.");
            if (!grupo.Matches.ContainsKey(idParticipante)) throw new Exception("Matches não gerados.");

            var idPresenteado = grupo.Matches[idParticipante];
            return grupo.Participantes.FirstOrDefault(p => p.Id == idPresenteado) ?? throw new Exception("Participante não encontrado.");
        }
    }
}
