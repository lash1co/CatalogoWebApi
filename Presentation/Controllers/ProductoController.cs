using Bussiness;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation.Controllers
{
    public class ProductoController : ApiController
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        
        //GET api/Producto
        public IEnumerable<Producto> Get() 
        { 
            return _productoService.GetAllProductos();
        }

        //GET api/Producto/{id}
        public Producto Get(int id) 
        { 
            return _productoService.GetProducto(id);
        }

        //GET api/Producto/string
        public IEnumerable<Producto> Get(string _string = null) 
        {
            return _productoService.SearchProducto(_string);
        }

        //POST api/Producto
        public void Post([FromBody] Producto producto) 
        {
            _productoService.AddProducto(producto);
        }

        //PUT api/Producto
        public void Put([FromBody] Producto producto) 
        { 
            _productoService.UpdateProducto(producto);
        }

        //DELETE api/Producto/{id}
        public void Delete(int id) 
        { 
            _productoService.DeleteProducto(id);
        }
    }
}
