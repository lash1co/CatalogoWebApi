using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Bussiness;
using DataAccess;
using DataAccess.Modelo;

namespace Presentation.Controllers
{
    public class CategoriaController : ApiController
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        //GET api/Categoria?page=1&pageSize=10
        public async Task<IHttpActionResult> Get(string page,string pageSize) 
        {
            bool pageIsNumber = int.TryParse(page, out var intPage);
            bool pageSizeIsNumber = int.TryParse(pageSize, out var intPageSize);

            if (!pageIsNumber  || !pageSizeIsNumber)
            {
                return BadRequest("El valor de página y del tamaño de la página debe ser númerico");
            }

            if (intPage < 1 || intPageSize < 1)
            {
                return BadRequest("El valor de página o del tamaño de la página no debe ser menor a 1");
            }

            return Ok(await _categoriaService.GetAllCategorias(intPage,intPageSize));
        }

        //GET api/Categoria/{id}
        public async Task<IHttpActionResult> Get(int id) 
        {
            try 
            {
                var categoria = await _categoriaService.GetCategoria(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                return Ok(categoria);
            }
            catch(Exception ex) 
            {
                return InternalServerError(ex);
            }
        }

        // POST api/Categoria
        public async Task<IHttpActionResult> Post([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                var errorMessage = ModelState.Values.FirstOrDefault(v => v.Errors.Any())?.Errors.FirstOrDefault()?.ErrorMessage;
                return BadRequest(errorMessage ?? "Modelo no válido!.");
            }

            if (string.IsNullOrEmpty(categoria?.Nombre?.Trim()))
            {
                return BadRequest("La categoria debe tener un nombre y no debe estar vacío.");
            }
            try 
            {
                await _categoriaService.AddCategoria(categoria);
                return CreatedAtRoute("DefaultApi", new { id = categoria.Id }, categoria);
            }
            catch(Exception ex) 
            {
                return InternalServerError(ex);
            }  
        }

        // PUT api/Categoria/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid || categoria?.Nombre == null || id == 0 || categoria?.Id == 0)
            {
                return BadRequest("modelo inválido! Id o Nombre no son válidos.");
            }

            if (id != categoria?.Id || categoria?.Nombre.Trim() == "")
            {
                return BadRequest("El Id de la categoria no coincide con el del modelo y/o el nombre de la categoria está vacío.");
            }
            try
            {
                if (!await _categoriaService.CategoriaExists(id))
                {
                    return NotFound();
                }
                await _categoriaService.UpdateCategoria(id, categoria);
                return Ok($"Categoria {id}  modificada");
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

        // DELETE api/Categoria/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try 
            {
                var categoria = await _categoriaService.GetCategoria(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                await _categoriaService.DeleteCategoria(categoria);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
