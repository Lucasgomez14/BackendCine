using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Command
{
    public class FuncionCommand : IFuncionCommand
    {
        private readonly CineBD _context;

        public FuncionCommand(CineBD DBContext)
        {
            _context = DBContext;
        }
        public async Task<int> InsertFuncion(Funcion funcion)
        {
            try
            {
                _context.Add(funcion);
                _context.SaveChanges();
                return funcion.FuncionId;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos: Problema en añadir la funcion");
            }
        }

        public async Task<Funcion> DeleteFuncion(Funcion funcion)
        {
            try
            {
                _context.Remove(funcion);
                await _context.SaveChangesAsync();
                return funcion;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos: Problema en eliminar la funcion");
            }
        }
    }
}
