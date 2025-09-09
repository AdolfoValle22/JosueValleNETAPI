
using AuthApi.DTOs.CategoriaJADTOs;
using AuthApi.Entidades;
using AuthApi.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Servicios
{
	public class CategoriaJAService : ICategoriaJAService
	{
		private readonly ICategoriaJARepository _repo;
		public CategoriaJAService(ICategoriaJARepository repo)
		{
			_repo = repo;
		}

		public async Task<IEnumerable<CategoriaJAListDto>> ObtenerTodasAsync()
		{
			var categorias = await _repo.ObtenerTodasAsync();
			return categorias.Select(c => new CategoriaJAListDto
			{
				Id = c.Id,
				Nombre = c.Nombre
			});
		}

		public async Task<CategoriaJADetailDto> ObtenerPorIdAsync(int id)
		{
			var c = await _repo.ObtenerPorIdAsync(id);
			if (c == null) return null;
			return new CategoriaJADetailDto
			{
				Id = c.Id,
				Nombre = c.Nombre,
				Descripcion = c.Descripcion
			};
		}

		public async Task<CategoriaJADetailDto> CrearAsync(CategoriaJACreateDto dto)
		{
			var categoria = new CategoriaJA
			{
				Nombre = dto.Nombre,
				Descripcion = dto.Descripcion
			};
			var creada = await _repo.CrearAsync(categoria);
			return new CategoriaJADetailDto
			{
				Id = creada.Id,
				Nombre = creada.Nombre,
				Descripcion = creada.Descripcion
			};
		}

		public async Task<bool> ActualizarAsync(CategoriaJAUpdateDto dto)
		{
			var categoria = await _repo.ObtenerPorIdAsync(dto.Id);
			if (categoria == null) return false;
			categoria.Nombre = dto.Nombre;
			categoria.Descripcion = dto.Descripcion;
			return await _repo.ActualizarAsync(categoria);
		}

		public async Task<bool> EliminarAsync(int id)
		{
			return await _repo.EliminarAsync(id);
		}

    }
}