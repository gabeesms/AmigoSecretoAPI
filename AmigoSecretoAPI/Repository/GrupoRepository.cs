using AmigoSecretoAPI.Data;
using AmigoSecretoAPI.Data.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;

namespace AmigoSecretoAPI.Repository
{
    public class GrupoRepository
    {
        private readonly DatabaseContext _context;

        public GrupoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<GrupoDto?> GetGrupoAsync(int id) =>
       await _context.Grupos.Include(g => g.Participantes).FirstOrDefaultAsync(g => g.Id == id);

        public async Task AddGrupoAsync(GrupoDto grupo)
        {
            _context.Grupos.Add(grupo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGrupoAsync(GrupoDto grupo)
        {
            _context.Grupos.Update(grupo);
            await _context.SaveChangesAsync();
        }
    }
}
