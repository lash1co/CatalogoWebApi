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

        public void DeleteProducto(Producto producto) 
        { 
                _dbContext.Producto.Remove(producto);
                _dbContext.SaveChanges();
        }

        public void AddProducto(Producto producto) 
        { 
            _dbContext.Producto.Add(producto);
            _dbContext.SaveChanges();
        }

        public void UpdateProducto(int id, Producto producto) 
        {
            var existingProducto = GetProducto(id);
            if (existingProducto != null) 
            { 
                if(producto.Nombre != null)
                    existingProducto.Nombre = producto.Nombre;
                if(producto.CategoriaId != 0)
                    existingProducto.CategoriaId = producto.CategoriaId;
                if(producto.Descripcion != null)
                    existingProducto.Descripcion= producto.Descripcion;
                if(producto.Imagen != null)
                    existingProducto.Imagen = producto.Imagen;
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Producto> SearchProducto(string searchText, string order) 
        { 
            var productos = _dbContext.Producto.Include(p => p.Categoria).AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                productos = productos.Where(p => p.Nombre.Contains(searchText)
                                             || p.Descripcion.Contains(searchText)
                                             || p.Categoria.Nombre.Contains(searchText));
            }
            switch (order)
            {
                case "name_asc":
                    productos = productos.OrderBy(p => p.Nombre);
                    break;
                case "name_desc":
                    productos = productos.OrderByDescending(p => p.Nombre);
                    break;
                case "category_asc":
                    productos = productos.OrderBy(p => p.Categoria.Nombre);
                    break;
                case "category_desc":
                    productos = productos.OrderByDescending(p => p.Categoria.Nombre);
                    break;
                default:
                    productos = productos.OrderBy(p => p.Nombre);
                    break;
            }
            return productos.ToList();
        }

        public bool ProductoExists(int id)
        {
            return _dbContext.Producto.Count(p => p.Id == id) > 0;
        }
    }
}
