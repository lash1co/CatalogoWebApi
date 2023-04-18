using DataAccess;
using DataAccess.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class CategoriaService: ICategoriaService
    {
        private readonly CatalogoDBEntities _dbContext;

        public CategoriaService(CatalogoDBEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoriaResponse> GetAllCategorias(int page = 1, int pageSize = 10) 
        {
            var categorias = _dbContext.Categoria.OrderBy(c=>c.Id).AsQueryable();
            var totalCategorias = await categorias.CountAsync();
            categorias = categorias.Skip(pageSize * (page - 1)).Take(pageSize);
            var listCategorias = await categorias.ToListAsync();
            var response = new CategoriaResponse(listCategorias, page, pageSize, totalCategorias);
            return response;

        }

        public async Task<Categoria> GetCategoria(int id) 
        { 
            return await _dbContext.Categoria.FindAsync(id);
        }

        public async Task AddCategoria(Categoria categoria) 
        { 
            _dbContext.Categoria.Add(categoria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoria(Categoria categoria) 
        { 
            _dbContext.Categoria.Remove(categoria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCategoria(int id, Categoria categoria) 
        { 
            var existingCategoria = await GetCategoria(id);
            if(existingCategoria != null && categoria.Nombre != null && categoria.Nombre.Trim() != "") 
            { 
                existingCategoria.Nombre= categoria.Nombre;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> CategoriaExists(int id)
        {
            return await _dbContext.Categoria.CountAsync(c => c.Id == id) > 0;
        }
    }
}
