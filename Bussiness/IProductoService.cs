using DataAccess;
using DataAccess.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public interface IProductoService
    {
        Task<Producto> GetProducto(int id);
        Task DeleteProducto(Producto producto);
        Task AddProducto(Producto producto);
        Task UpdateProducto(int id, Producto producto);
        Task<ProductoResponse> GetAllProductos(string searchText, string order, int page, int numberProducts);
        Task<bool> ProductoExists(int id);
    }
}
