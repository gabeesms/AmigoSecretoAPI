using AmigoSecreto.domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AmigoSecreto.infra.Data
{
    public class AmigoSecretoContext : DbContext
    {
        public AmigoSecretoContext(DbContextOptions<AmigoSecretoContext> options) : base(options) { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Participante> Participantees { get; set; }
        public DbSet<Match> Matches { get; set; }
    }
}
