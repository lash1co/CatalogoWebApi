using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetAllProductos();
        Producto GetProducto(int id);
        void DeleteProducto(Producto producto);
        void AddProducto(Producto producto);
        void UpdateProducto(int id, Producto producto);
        IEnumerable<Producto> SearchProducto(string searchText, string order);
        bool ProductoExists(int id);
    }
}
