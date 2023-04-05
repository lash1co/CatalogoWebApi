using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetAllCategorias();
        Categoria GetCategoria(int id);
        void AddCategoria(Categoria categoria);
        void DeleteCategoria(Categoria categoria);
        void UpdateCategoria(int id, Categoria categoria);
        bool CategoriaExists(int id);
    }
}
