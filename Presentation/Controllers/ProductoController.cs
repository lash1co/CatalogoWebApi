using Bussiness;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Presentation.Controllers
{
    public class ProductoController : ApiController
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        //GET api/Producto/{id}
        public IHttpActionResult Get(int id)
        {
            try
            {
                var producto = _productoService.GetProducto(id);
                if (producto == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(producto);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //GET api/Producto?q=null(name=Ideapad&description=Lenovo&category=Laptop)&order=name_asc
        public IEnumerable<Producto> Get(string q = null, string order = null) 
        {
            return _productoService.GetAllProductos(q, order);
        }

        //POST api/Producto
        public IHttpActionResult Post([FromBody] Producto producto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try 
            {
                _productoService.AddProducto(producto);
                return CreatedAtRoute("DefaultApi", new { id = producto.Id }, producto);
            }
            catch(Exception ex) 
            { 
                return InternalServerError(ex);
            }
        }

        //PUT api/Producto
        public IHttpActionResult Put(int id, [FromBody] Producto producto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto.Id)
            {
                return BadRequest();
            }
            try 
            {
                _productoService.UpdateProducto(id, producto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_productoService.ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //return StatusCode(HttpStatusCode.NoContent);
            return Ok($"Producto {id}  modificado");
        }

        //DELETE api/Producto/{id}
        public IHttpActionResult Delete(int id)
        {
            try 
            {
                var producto = _productoService.GetProducto(id);
                if (producto == null)
                {
                    return NotFound();
                }
                _productoService.DeleteProducto(producto);
                return Ok(producto);
            }
            catch(Exception ex) 
            {
                return InternalServerError(ex);
            }
        }
    }
}
