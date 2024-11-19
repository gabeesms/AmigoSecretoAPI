using AmigoSecretoAPI.Data.Dto;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace AmigoSecretoAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts)
         : base(opts)
        {

        }
        public DbSet<GrupoDto> Grupos { get; set; }
        public DbSet<ParticipanteDto> Participantes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GrupoDto>().HasMany(g => g.Participantes).WithOne().OnDelete(DeleteBehavior.Cascade);

        }

    }
}
