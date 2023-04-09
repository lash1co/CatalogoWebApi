using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
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

        public async Task<Producto> GetProducto(int id) 
        { 
            return await _dbContext.Producto.FindAsync(id);
        }

        public async Task DeleteProducto(Producto producto) 
        { 
                _dbContext.Producto.Remove(producto);
                await _dbContext.SaveChangesAsync();
        }

        public async Task AddProducto(Producto producto) 
        { 
            _dbContext.Producto.Add(producto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProducto(int id, Producto producto) 
        {
            var existingProducto = await GetProducto(id);
            if (existingProducto != null) 
            { 
                if(producto.Nombre != null && producto.Nombre.Trim() != "")
                    existingProducto.Nombre = producto.Nombre;
                if(producto.CategoriaId != 0)
                    existingProducto.CategoriaId = producto.CategoriaId;
                if(producto.Descripcion != null && producto.Descripcion.Trim() != "")
                    existingProducto.Descripcion= producto.Descripcion;
                if(producto.Imagen != null && producto.Imagen.Trim() != "")
                    existingProducto.Imagen = producto.Imagen;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Producto>> GetAllProductos(string searchText, string order) 
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
            return await productos.ToListAsync();
        }

        public async Task<bool> ProductoExists(int id)
        {
            return await _dbContext.Producto.CountAsync(p => p.Id == id) > 0;
        }
    }
}
