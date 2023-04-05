using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWebApi.Models
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ObtenerCategorias();
        Task<Categoria> ObtenerCategoriaPorId(int id);
        Task AgregarCategoria(Categoria categoria);
        Task ActualizarCategoria(Categoria categoria);
        Task EliminarCategoria(int id);
    }
}
