using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Modelo
{
    public class PaginationInfo
    {
        public int CurrentPage { get; set;}
        public int TotalProductos { get; set;}
        public int TotalPages { get; set;}

        public PaginationInfo(int currentPage, int totalProductos, int totalPages) { 
            CurrentPage = currentPage;
            TotalProductos = totalProductos;
            TotalPages = totalPages;
        }
    }
}
