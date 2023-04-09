using DataAccess;
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

        public async Task<IEnumerable<Categoria>> GetAllCategorias() 
        { 
            return await _dbContext.Categoria.ToListAsync();
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
