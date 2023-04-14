using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Modelo
{
    public class Response
    {
        public IEnumerable<Producto> Productos { get;}
        //public PaginationInfo PaginationInfo { get; set; }
        public int CurrentPage { get;}
        public int TotalProductos { get;}
        public int FirstProducto { get; }
        public int LastProducto { get; }
        public int TotalPages { get;}

        public Response(IEnumerable<Producto> productos, int currentPage, int totalProductos, int pageSize) {
            Productos = productos;
            CurrentPage = currentPage;
            TotalProductos = totalProductos;
            double productosPerPage = (double)totalProductos / pageSize;
            TotalPages = (int)Math.Ceiling(productosPerPage);
            FirstProducto = ((currentPage - 1) * TotalPages) + 1;
            LastProducto = Math.Min(FirstProducto + TotalPages - 1, TotalProductos);
        }
    }
}
