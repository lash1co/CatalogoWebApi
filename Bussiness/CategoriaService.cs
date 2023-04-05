using DataAccess;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Categoria> GetAllCategorias() 
        { 
            return _dbContext.Categoria.ToList();
        }

        public Categoria GetCategoria(int id) 
        { 
            return _dbContext.Categoria.Find(id);
        }

        public void AddCategoria(Categoria categoria) 
        { 
            _dbContext.Categoria.Add(categoria);
            _dbContext.SaveChanges();
        }

        public void DeleteCategoria(int id) 
        { 
            var categoria = GetCategoria(id); 
            if(categoria != null) 
            { 
                _dbContext.Categoria.Remove(categoria);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateCategoria(Categoria categoria) 
        { 
            var existingCategoria = GetCategoria(categoria.Id);
            if(existingCategoria != null) 
            { 
                existingCategoria.Nombre= categoria.Nombre;
                _dbContext.SaveChanges();
            }
        }
    }
}
