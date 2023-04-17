using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Modelo
{
    public class PaginationInfo
    {
        public int CurrentPage { get;}
        public int TotalItems { get;}
        public int TotalPages { get;}
        public int TotalItemsInPage { get;}
        public int FirstItem { get; }
        public int LastItem { get; }

        public PaginationInfo(int currentPage, int totalItems, int pageSize, int totalItemsInPage) { 
            CurrentPage = currentPage;
            TotalItems = totalItems;
            TotalItemsInPage = totalItemsInPage;
            double itemsPerPage = (double)totalItems / pageSize;
            TotalPages = (int)Math.Ceiling(itemsPerPage);
            FirstItem = ((currentPage - 1) * pageSize) + 1;
            LastItem = ((currentPage - 1) * pageSize) + totalItemsInPage;
        }
    }
}
