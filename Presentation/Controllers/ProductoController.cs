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
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class ProductoController : ApiController
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaService _categoriaService;

        public ProductoController(IProductoService productoService, ICategoriaService categoriaService)
        {
            _productoService = productoService;
            _categoriaService= categoriaService;
        }

        //GET api/Producto/{id}
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var producto = await _productoService.GetProducto(id);
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
        public async Task<IEnumerable<Producto>> Get(string q = null, string order = null) 
        {
            return await _productoService.GetAllProductos(q, order);
        }

        //POST api/Producto
        public async Task<IHttpActionResult> Post([FromBody] Producto producto) 
        {
            if (!ModelState.IsValid)
            {
                var errorMessage = ModelState.Values.FirstOrDefault(v => v.Errors.Any())?.Errors.FirstOrDefault()?.ErrorMessage;
                return BadRequest(errorMessage ?? "Modelo no válido!.");
            }
            if (producto?.CategoriaId == 0 || string.IsNullOrEmpty(producto?.Nombre?.Trim()) || string.IsNullOrEmpty(producto?.Descripcion?.Trim()) || string.IsNullOrEmpty(producto?.Imagen?.Trim()))
            {
                return BadRequest("El producto no tiene definido correctamente uno o varios de sus parametros (Nombre, Descripcion, Imagen, CategoriaId)");
            }
            try 
            {
                if(!await _categoriaService.CategoriaExists(producto.CategoriaId)) 
                {
                    return BadRequest("La categoria vinculada al producto no existe.");
                }
                await _productoService.AddProducto(producto);
                return CreatedAtRoute("DefaultApi", new { id = producto.Id }, producto);
            }
            catch(Exception ex) 
            { 
                return InternalServerError(ex);
            }
        }

        //PUT api/Producto
        public async Task<IHttpActionResult> Put(int id, [FromBody] Producto producto) 
        {
            if (!ModelState.IsValid || (producto?.Nombre == null && producto?.Descripcion == null && producto?.Imagen == null) || id == 0 || producto?.Id == 0)
            {
                var errorMessage = ModelState.Values.FirstOrDefault(v => v.Errors.Any())?.Errors.FirstOrDefault()?.ErrorMessage;
                return BadRequest(errorMessage ?? "Modelo no válido!. El Id del producto y/o el modelo no tiene parametros o está nulo.");
            }
            if (producto?.CategoriaId == 0 || (producto?.Nombre?.Trim() == "" && producto?.Descripcion?.Trim() == "" && producto?.Imagen?.Trim() == ""))
            {
                return BadRequest("La categoria del producto esta mal definida y/o todos los otros parametros estan vacíos.");
            }

            if (id != producto.Id)
            {
                return BadRequest("El Id no coincide con el del modelo");
            }
            try 
            {
                if (!await _productoService.ProductoExists(id))
                {
                    return NotFound();
                }
                if (!await _categoriaService.CategoriaExists(producto.CategoriaId))
                {
                    return BadRequest("La categoria vinculada al producto no existe.");
                }
                await _productoService.UpdateProducto(id, producto);
                return Ok($"Producto {id}  modificado");
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(HttpStatusCode.Conflict);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        //DELETE api/Producto/{id}
        public async Task<IHttpActionResult> Delete(int id)
        {
            try 
            {
                var producto = await _productoService.GetProducto(id);
                if (producto == null)
                {
                    return NotFound();
                }
                await _productoService.DeleteProducto(producto);
                return Ok(producto);
            }
            catch(Exception ex) 
            {
                return InternalServerError(ex);
            }
        }
    }
}
