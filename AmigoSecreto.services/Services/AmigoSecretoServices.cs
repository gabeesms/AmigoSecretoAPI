using System;
using AmigoSecreto.domain.Entidades;
using AmigoSecreto.domain.Interfaces;

namespace AmigoSecreto.services.Services
{
    public class AmigoSecretoServices
    {
        private readonly IAmigoSecretoRepository _repository;

        public AmigoSecretoServices(IAmigoSecretoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Group> CreateGroup(Group group)
        {
            return await _repository.CreateGroup(group);
        }

        public async Task<Participante> AddParticipante(int groupId, Participante participante)
        {
            return await _repository.AddParticipante(groupId, participante);
        }

        public async Task<List<Match>> GenerateMatches(int groupId)
        {
            var participantes = await _repository.GetMatches(groupId);

            if (participantes == null || participantes.Count < 2) throw new Exception("É necessário pelo menos 2 participantes");

            var random = new Random();
            var sorteioParticipantes = participantes.OrderBy(x => random.Next()).ToList();

            var matches = new List<Match>();

            for (int i = 0; i < sorteioParticipantes.Count; i++)
            {
                var giver = sorteioParticipantes[i];
                var receiver = sorteioParticipantes[(i + 1) % sorteioParticipantes.Count];
                matches.Add(new Match { GiverId = giver.Id, ReceiverId = receiver.Id });

                return matches;

            }
        }

        public async Task<List<Match>> GetMatches(int groupId)
        {
            return await _repository.GetMatches(groupId);
        }
    }
}
