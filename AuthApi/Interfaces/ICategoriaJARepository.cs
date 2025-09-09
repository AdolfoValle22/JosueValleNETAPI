using AuthApi.Controllers;
using AuthApi.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApi.Interfaces
{
    public interface ICategoriaJARepository
    {
        Task<IEnumerable<CategoriaJA>> ObtenerTodasAsync();
        Task<CategoriaJA> ObtenerPorIdAsync(int id);
        Task<CategoriaJA> CrearAsync(CategoriaJA categoria);
        Task<bool> ActualizarAsync(CategoriaJA categoria);
        Task<bool> EliminarAsync(int id);
    }
}