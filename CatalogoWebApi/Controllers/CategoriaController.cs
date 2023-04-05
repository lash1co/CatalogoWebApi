using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CatalogoWebApi.Models;
using CatalogoWebApi.Servicios;

namespace CatalogoWebApi.Controllers
{
    public class CategoriaController : ApiController
    {
        private CatalogoDBEntities db = new CatalogoDBEntities();

        // GET: api/Categoria
        public IQueryable<Categoria> GetCategoria()
        {
            return db.Categoria;
        }

        // GET: api/Categoria/5
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> GetCategoria(int id)
        {
            Categoria categoria = await db.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // PUT: api/Categoria/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.Id)
            {
                return BadRequest();
            }

            db.Entry(categoria).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categoria
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> PostCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categoria.Add(categoria);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categoria/5
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> DeleteCategoria(int id)
        {
            Categoria categoria = await db.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            db.Categoria.Remove(categoria);
            await db.SaveChangesAsync();

            return Ok(categoria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaExists(int id)
        {
            return db.Categoria.Count(e => e.Id == id) > 0;
        }
        //private readonly ICategoriaService _categoriaService;

        //public CategoriaController(ICategoriaService categoriaService)
        //{
        //    _categoriaService = categoriaService;
        //}

        //[HttpGet]
        //public async Task<IEnumerable<Categoria>> ObtenerCategorias()
        //{
        //    return await _categoriaService.ObtenerCategorias();
        //}

        //[HttpGet]
        //public async Task<Categoria> ObtenerCategoriaPorId(int id)
        //{
        //    return await _categoriaService.ObtenerCategoriaPorId(id);
        //}

        //[HttpPost]
        //public async Task AgregarCategoria(Categoria categoria)
        //{
        //    await _categoriaService.AgregarCategoria(categoria);
        //}

        //[HttpPut]
        //public async Task ActualizarCategoria(Categoria categoria)
        //{
        //    await _categoriaService.ActualizarCategoria(categoria);
        //}

        //[HttpDelete]
        //public async Task EliminarCategoria(int id)
        //{
        //    await _categoriaService.EliminarCategoria(id);
        //}
    }
}