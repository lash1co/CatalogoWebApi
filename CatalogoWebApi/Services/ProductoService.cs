using CatalogoWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWebApi.Servicios
{
    public class ProductoService: IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return await _productoRepository.ObtenerProductos();
        }

        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            return await _productoRepository.ObtenerProductoPorId(id);
        }

        public async Task AgregarProducto(Producto producto)
        {
            await _productoRepository.AgregarProducto(producto);
        }

        public async Task ActualizarProducto(Producto producto)
        {
            await _productoRepository.ActualizarProducto(producto);
        }

        public async Task EliminarProducto(int id)
        {
            await _productoRepository.EliminarProducto(id);
        }
    }
}