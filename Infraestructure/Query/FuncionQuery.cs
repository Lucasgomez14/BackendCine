using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class FuncionQuery : IFuncionQuery
    {
        private readonly CineBD _context;

        public FuncionQuery(CineBD DBContext)
        {
            _context = DBContext;
        }

        public async Task<List<Funcion>> GetFuncionesByDate(DateTime fecha)
        {
            try
            {
                List<Funcion> FuncionesPorFecha = _context.Funciones
                .Include(fun => fun.Pelicula)
                .Include(fun => fun.Pelicula.Genero)
                .Include(fun => fun.Sala)
                .Where(fun => fun.Fecha.Date == fecha.Date)
                .ToList();
                return FuncionesPorFecha;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos: Problema con la fecha");
            }

        }

        public async Task<List<Funcion>> GetFuncionesByTitle(string title)
        {
            try
            {
                List<Funcion> FuncionesPorTitulo = _context.Funciones
               .Include(pel => pel.Pelicula)
               .Include(fun => fun.Pelicula.Genero)
               .Include(fun => fun.Sala)
               .Where(pel => pel.Pelicula.Titulo.Contains(title))
               .ToList();
                return FuncionesPorTitulo;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos: Problema con el titulo");
            }
        }
        public async Task<List<Funcion>> GetAllFunciones()
        {
            try
            {
                List<Funcion> todasLasFunciones = _context.Funciones
                .Include(f => f.Sala)
                .Include(f => f.Pelicula)
                .Include(f => f.Pelicula.Genero)
                .Include(f => f.Tickets)
                .ToList();

                return todasLasFunciones;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos: Problema al obtener funciones");
            }
        }

        public async Task<Funcion> GetFuncionById(int id)
        {
            try
            {
                return await _context.Funciones
                    .Include(f => f.Sala)
                    .Include(f => f.Pelicula)
                    .Include(f => f.Pelicula.Genero)
                    .Include(f => f.Tickets)
                    .SingleOrDefaultAsync(f => f.FuncionId == id);
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos: Problema al obtener una funcion");
            }
        }

        public async Task<List<Funcion>> GetFuncionByCategory(int categoryId)
        {
            try
            {
                List<Funcion> funcionesPorCategoria = _context.Funciones
               .Include(pel => pel.Pelicula)
               .Include(fun => fun.Pelicula.Genero)
               .Include(fun => fun.Sala)
               .Where(pel => pel.Pelicula.GeneroId == categoryId)
               .ToList();
                return funcionesPorCategoria;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos: Problema con el titulo");
            }
        }
    }
}
