using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWebApi.Models
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerProductos();
        Task<Producto> ObtenerProductoPorId(int id);
        Task AgregarProducto(Producto producto);
        Task ActualizarProducto(Producto producto);
        Task EliminarProducto(int id);
    }
}
