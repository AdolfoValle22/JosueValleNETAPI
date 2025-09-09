using AuthApi.DTOs.CategoriaJADTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApi.Interfaces
{
    public interface ICategoriaJAService
    {
        Task<IEnumerable<CategoriaJAListDto>> ObtenerTodasAsync();
        Task<CategoriaJADetailDto> ObtenerPorIdAsync(int id);
        Task<CategoriaJADetailDto> CrearAsync(CategoriaJACreateDto dto);
        Task<bool> ActualizarAsync(CategoriaJAUpdateDto dto);
        Task<bool> EliminarAsync(int id);
    }
}