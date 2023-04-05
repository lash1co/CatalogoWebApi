using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bussiness;
using DataAccess;

namespace Presentation.Controllers
{
    public class CategoriaController : ApiController
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        //GET api/Categoria
        public IEnumerable<Categoria> Get() 
        {
            return _categoriaService.GetAllCategorias();
        }

        //GET api/Categoria/{id}
        public Categoria Get(int id) 
        {
            return _categoriaService.GetCategoria(id);
        }

        // POST api/Categoria
        public void Post([FromBody] Categoria categoria)
        {
            _categoriaService.AddCategoria(categoria);
        }

        // PUT api/Categoria/5
        public void Put([FromBody] Categoria categoria)
        {
            _categoriaService.UpdateCategoria(categoria);
        }

        // DELETE api/Categoria/5
        public void Delete(int id)
        {
            _categoriaService.DeleteCategoria(id);
        }
    }
}
