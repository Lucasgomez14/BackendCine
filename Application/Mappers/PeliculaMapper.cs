﻿using Application.Interfaces;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class PeliculaMapper: IPeliculaMapper
    {
        private readonly IGeneroMapper _generoMapper;


        public PeliculaMapper (IGeneroMapper generoMapper)
        {
            _generoMapper = generoMapper;
        }

        public async Task<PeliculaGetResponse> GeneratePeliculaGetResponse(Pelicula pelicula)
        {
            return new PeliculaGetResponse
            {
                peliculaId = pelicula.PeliculaId,
                titulo = pelicula.Titulo,
                poster = pelicula.Poster,
                genero = await _generoMapper.GetGeneroMapper(pelicula.Genero),
                //genero = new Response.Genero
                //{
                //    id = newFuncion.Pelicula.Genero.GeneroId,
                //    nombre = newFuncion.Pelicula.Genero.Nombre,
                //},
            };
        }

        public async Task<PeliculaResponse> GeneratePeliculaResponse(Pelicula unaPelicula)
        {
            return new PeliculaResponse
            {
                peliculaId = unaPelicula.PeliculaId,
                titulo = unaPelicula.Titulo,
                poster = unaPelicula.Poster,
                sinopsis = unaPelicula.Sinopsis,
                genero = await _generoMapper.GetGeneroMapper(unaPelicula.Genero),
                //genero = new Response.Genero
                //{
                //    id = unaPelicula.Genero.GeneroId,
                //    nombre = unaPelicula.Genero.Nombre,
                //},
                funciones = await GenerateDeleteFunciones(unaPelicula.Funciones),
            };
        }

        private async Task<FuncionDelete> GenerateFuncionDelete(Funcion newFuncion)
        {
            return new FuncionDelete
            {
                funcionId = newFuncion.FuncionId,
                fecha = newFuncion.Fecha.ToString("dd-MM-yyyy"),
                horario = newFuncion.Horario.ToString("hh\\:mm")
            };
        }

        private async Task<List<FuncionDelete>> GenerateDeleteFunciones(ICollection<Funcion> listaFunciones)
        {
            List<FuncionDelete> funcionesDelete = new();
            foreach (Funcion unaFuncion in listaFunciones)
            {
                funcionesDelete.Add(await GenerateFuncionDelete(unaFuncion));
                //FuncionDelete funcion = new FuncionDelete
                //{
                //    funcionId = unaFuncion.FuncionId,
                //    fecha = unaFuncion.Fecha.ToString("yyyy-MM-dd"),
                //    horario = unaFuncion.Horario.ToString(),
                //};

            }
            return funcionesDelete;
        }
    }
}
