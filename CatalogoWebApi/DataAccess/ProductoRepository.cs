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
    public class ProductoRepository : IProductoRepository
    {
        private readonly CatalogoDBEntities _entities;
        public ProductoRepository(CatalogoDBEntities entities) 
        {
            _entities= entities;
        }
        public async Task ActualizarProducto(Producto producto)
        {
            _entities.Entry(producto).State = EntityState.Modified;
            await _entities.SaveChangesAsync();
        }

        public async Task AgregarProducto(Producto producto)
        {
            _entities.Producto.Add(producto);
            await _entities.SaveChangesAsync();
        }

        public async Task EliminarProducto(int id)
        {
            var producto = await ObtenerProductoPorId(id);
            _entities.Producto.Remove(producto);
            await _entities.SaveChangesAsync();
        }

        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            return await _entities.Producto.FindAsync(id);
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return await _entities.Producto.ToListAsync();
        }
    }
}