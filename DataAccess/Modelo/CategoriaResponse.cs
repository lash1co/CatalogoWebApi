using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Modelo
{
    public class CategoriaResponse
    {
        public IEnumerable<Categoria> Categorias { get; }
        public PaginationInfo Pagination { get; }

        public CategoriaResponse(IEnumerable<Categoria> categorias, int currentPage, int pageSize, int totalCategorias) 
        { 
            Categorias= categorias;
            Pagination = new PaginationInfo(currentPage, totalCategorias, pageSize, categorias.Count());
        }

    }
}
