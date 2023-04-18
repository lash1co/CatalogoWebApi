﻿using DataAccess;
using DataAccess.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public interface ICategoriaService
    {
        Task<CategoriaResponse> GetAllCategorias(int page, int numberCategorias);
        Task<Categoria> GetCategoria(int id);
        Task AddCategoria(Categoria categoria);
        Task DeleteCategoria(Categoria categoria);
        Task UpdateCategoria(int id, Categoria categoria);
        Task<bool> CategoriaExists(int id);
    }
}
