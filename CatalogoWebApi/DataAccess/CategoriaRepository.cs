using CatalogoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWebApi.DataAccess
{
    public class CategoriaRepository: ICategoriaRepository
    {
        private readonly CatalogoDBEntities _entities;

        public CategoriaRepository(CatalogoDBEntities entities)
        {
            _entities = entities;
        }

        public async Task ActualizarCategoria(Categoria categoria)
        {
            _entities.Entry(categoria).State = EntityState.Modified;
            await _entities.SaveChangesAsync();
        }

        public async Task AgregarCategoria(Categoria categoria)
        {
            _entities.Categoria.Add(categoria);
            await _entities.SaveChangesAsync();
        }

        public async Task EliminarCategoria(int id)
        {
            var categoria = await ObtenerCategoriaPorId(id);
            _entities.Categoria.Remove(categoria);
            await _entities.SaveChangesAsync();
        }

        public async Task<Categoria> ObtenerCategoriaPorId(int id)
        {
            return await _entities.Categoria.FindAsync(id);
        }

        public async Task<IEnumerable<Categoria>> ObtenerCategorias()
        {
            return await _entities.Categoria.ToListAsync();
        }
    }
}