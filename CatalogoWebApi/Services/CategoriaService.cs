using CatalogoWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWebApi.Servicios
{
    public class CategoriaService: ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> ObtenerCategorias()
        {
            return await _categoriaRepository.ObtenerCategorias();
        }

        public async Task<Categoria> ObtenerCategoriaPorId(int id)
        {
            return await _categoriaRepository.ObtenerCategoriaPorId(id);
        }

        public async Task AgregarCategoria(Categoria categoria)
        {
            await _categoriaRepository.AgregarCategoria(categoria);
        }

        public async Task ActualizarCategoria(Categoria categoria)
        {
            await _categoriaRepository.ActualizarCategoria(categoria);
        }

        public async Task EliminarCategoria(int id)
        {
            await _categoriaRepository.EliminarCategoria(id);
        }
    }
}