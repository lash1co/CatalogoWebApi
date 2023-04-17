using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Modelo
{
    public class ProductoResponse
    {
        public IEnumerable<Producto> Productos { get;}
        public PaginationInfo Pagination { get; }

        public ProductoResponse(IEnumerable<Producto> productos, int currentPage, int pageSize, int totalProductos) {
            Productos = productos;
            Pagination = new PaginationInfo(currentPage, totalProductos, pageSize, productos.Count());
        }
    }
}
