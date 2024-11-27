using AmigoSecreto.domain.Entidades;
using AmigoSecreto.domain.Interfaces;
using AmigoSecreto.infra.Data;
using Microsoft.EntityFrameworkCore;

namespace AmigoSecreto.infra.Repository
{
    public class AmigoSecretoRepository : IAmigoSecretoRepository
    {
        private readonly AmigoSecretoContext _context;

        public AmigoSecretoRepository(AmigoSecretoContext context)
        {
            _context = context;
        }

        public async Task<Group> CreateGroup(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task<Participante> AddParticipante(int groupId, Participante participante)
        {
            participante.GroupId = groupId;
            _context.Participantees.Add(participante);
            await _context.SaveChangesAsync();
            return participante;
        }

        public async Task<List<Match>> GetMatches(int groupId)
        {
            return await _context.Matches
                .Include(m => m.Giver)
                .Include(m => m.Receiver)
                .Where(m => m.Giver.GroupId == groupId)
                .ToListAsync() ?? new List<Match>();
        }

    }
}
