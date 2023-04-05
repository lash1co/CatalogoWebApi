using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class ProductoService: IProductoService
    {
        private readonly CatalogoDBEntities _dbContext;
        public ProductoService(CatalogoDBEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Producto> GetAllProductos() 
        {
            return _dbContext.Producto.ToList();
        }

        public Producto GetProducto(int id) 
        { 
            return _dbContext.Producto.Find(id);
        }

        public void DeleteProducto(int id) 
        { 
            var producto = GetProducto(id);
            if(producto != null) 
            {
                _dbContext.Producto.Remove(producto);
                _dbContext.SaveChanges();
            } 
        }

        public void AddProducto(Producto producto) 
        { 
            _dbContext.Producto.Add(producto);
            _dbContext.SaveChanges();
        }

        public void UpdateProducto(Producto producto) 
        {
            var existingProducto = GetProducto(producto.Id);
            if (existingProducto != null) 
            { 
                existingProducto.Nombre = producto.Nombre;
                existingProducto.CategoriaId = producto.CategoriaId;
                existingProducto.Descripcion= producto.Descripcion;
                existingProducto.Imagen = producto.Imagen;
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Producto> SearchProducto(string searchText) 
        { 
            var productos = _dbContext.Producto.Include(p => p.Categoria).AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                productos = productos.Where(p => p.Nombre.Contains(searchText)
                                             || p.Descripcion.Contains(searchText)
                                             || p.Categoria.Nombre.Contains(searchText));
            }
            return productos.ToList();
        }
    }
}
