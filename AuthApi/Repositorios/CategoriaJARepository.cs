using AuthApi.Entidades;
using AuthApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApi.Repositorios
{
    public class CategoriaJARepository : ICategoriaJARepository
    {
        private readonly AppDbContext _context;
        public CategoriaJARepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriaJA>> ObtenerTodasAsync()
        {
            return await _context.CategoriasJA.ToListAsync();
        }

        public async Task<CategoriaJA> ObtenerPorIdAsync(int id)
        {
            return await _context.CategoriasJA.FindAsync(id);
        }

        public async Task<CategoriaJA> CrearAsync(CategoriaJA categoria)
        {
            _context.CategoriasJA.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> ActualizarAsync(CategoriaJA categoria)
        {
            _context.CategoriasJA.Update(categoria);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var categoria = await _context.CategoriasJA.FindAsync(id);
            if (categoria == null) return false;
            _context.CategoriasJA.Remove(categoria);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}