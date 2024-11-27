using AmigoSecreto.domain.Entidades;

namespace AmigoSecreto.domain.Interfaces
{
    public interface IAmigoSecretoRepository
    {
        Task<Group> CreateGroup(Group group);
        Task<Participante> AddParticipante(int groupId, Participante participante);
        Task<List<Match>> GetMatches(int groupId);
    }
}
