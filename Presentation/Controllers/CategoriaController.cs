﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
        public IHttpActionResult Get(int id) 
        {
            try 
            {
                var categoria = _categoriaService.GetCategoria(id);
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
        public IHttpActionResult Post([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try 
            {
                _categoriaService.AddCategoria(categoria);
                return CreatedAtRoute("DefaultApi", new { id = categoria.Id }, categoria);
            }
            catch(Exception ex) 
            {
                return InternalServerError(ex);
            }  
        }

        // PUT api/Categoria/5
        public IHttpActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.Id)
            {
                return BadRequest();
            }
            try
            {
                _categoriaService.UpdateCategoria(id, categoria);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_categoriaService.CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //return StatusCode(HttpStatusCode.NoContent);
            return Ok($"Categoria {id}  modificada");
        }

        // DELETE api/Categoria/5
        public IHttpActionResult Delete(int id)
        {
            try 
            {
                var categoria = _categoriaService.GetCategoria(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                _categoriaService.DeleteCategoria(categoria);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
