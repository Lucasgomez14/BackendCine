﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Net.WebRequestMethods;

namespace Infraestructure.Data
{
    public class PeliculasData : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.HasData(
            new Pelicula { PeliculaId = 1, GeneroId = 1, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/aeg2.jpg", Sinopsis = "Después de los devastadores eventos ocurridos en Vengadores: Infinity War, el universo está en ruinas debido a las acciones de Thanos, el Titán Loco. Tras la derrota, las cosas no pintan bien para los Vengadores.", Titulo = "Avengers: End Game", Trailer = "https://www.youtube.com/embed/PyakRSni-c0" },
            new Pelicula { PeliculaId = 2, GeneroId = 1, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/aiw2.jpg", Sinopsis = "Un nuevo peligro acecha procedente de las sombras del cosmos. Thanos, el infame tirano intergaláctico, tiene como objetivo reunir las seis Gemas del Infinito y usarlas para imponer su perversa voluntad a toda la existencia.", Titulo = "Avengers: Infinity War", Trailer = "https://www.youtube.com/embed/823iAZOEKt8" },
            new Pelicula { PeliculaId = 3, GeneroId = 2, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/pc3.jpg", Sinopsis = "El capitán Jack Sparrow se embarca en una trepidante aventura para recuperar su querido barco, el Perla Negra, que ha sido robado por su rival, el capitán Barbossa.", Titulo = "Piratas del Caribe: La Maldición del Perla Negra", Trailer = "https://www.youtube.com/embed/5Itr2jHuJaw" },
            new Pelicula { PeliculaId = 4, GeneroId = 2, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/ij4.jpg", Sinopsis = "El arqueólogo y aventurero Indiana Jones (interpretado por Harrison Ford) es reclutado por el gobierno de los Estados Unidos para encontrar el Arca de la Alianza antes de que los nazis lo hagan.", Titulo = "Indiana Jones y los Cazadores del Arca Perdida", Trailer = "https://www.youtube.com/embed/ceMf9xtDA6U" },
            new Pelicula { PeliculaId = 5, GeneroId = 3, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/is5.jpg", Sinopsis = "En un futuro donde la Tierra se enfrenta a la escasez de recursos y la decadencia ambiental, un grupo de exploradores espaciales liderados por el piloto Cooperse embarca en una misión interestelar para encontrar un nuevo hogar para la humanidad.", Titulo = "Interestelar", Trailer = "https://www.youtube.com/embed/LYS2O1nl9iM" },
            new Pelicula { PeliculaId = 6, GeneroId = 3, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/op6.jpg", Sinopsis = "En tiempos de guerra, el brillante físico estadounidense Julius Robert Oppenheimer, al frente del proyecto Manhattan, lidera los ensayos nucleares para construir la bomba atómica para su país.", Titulo = "OppenHeimer", Trailer = "https://www.youtube.com/embed/MVvGSBKV504" },
            new Pelicula { PeliculaId = 7, GeneroId = 4, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/or7.jpg", Sinopsis = "Origen sigue a Dom Cobb, un ladrón habilidoso que se especializa en el robo de secretos a través de la invasión de los sueños de otras personas. Sin embargo, su última misión implica la tarea inversa: implantar una idea en la mente de alguien.", Titulo = "Origen", Trailer = "https://www.youtube.com/embed/RV9L7ui9Cn8" },
            new Pelicula { PeliculaId = 8, GeneroId = 4, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/ma8.jpg", Sinopsis = "Matrix presenta a Neo, un programador de software que, se une a un grupo de rebeldes que luchan contra una inteligencia artificial que ha esclavizado a la humanidad en una realidad simulada llamada la Matriz.", Titulo = "Matrix", Trailer = "https://www.youtube.com/embed/sMkNB8v-0uQ" },
            new Pelicula { PeliculaId = 9, GeneroId = 5, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/pa9.jpg", Sinopsis = "Kevin McCallister es un niño de ocho años que es accidentalmente dejado atrás cuando su familia se va de vacaciones durante la Navidad. Mientras se encuentra solo en casa, Kevin debe defender su hogar de dos torpes ladrones que intentan robarlo.", Titulo = "Mi Pobre Angelito", Trailer = "https://www.youtube.com/embed/KSpCNBIo92A" },
            new Pelicula { PeliculaId = 10, GeneroId = 5, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/sb10.jpg", Sinopsis = "Dos amigos de preparatoria, Seth y Evan, están a punto de graduarse y enfrentan la realidad de que sus caminos podrían separarse. Deciden asistir a una fiesta con la esperanza de perder su virginidad antes de la graduación.", Titulo = "Superbad", Trailer = "https://www.youtube.com/embed/au2Zq8D9RaY" },
            new Pelicula { PeliculaId = 11, GeneroId = 6, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/sm11.jpg", Sinopsis = "Buscando a Sugar Man narra la historia de Sixto Rodríguez, un músico folk estadounidense que, a pesar de no haber tenido éxito comercial en su propio país, se convirtió en una leyenda musical en Sudáfrica durante los años 70.", Titulo = "Buscando a Sugar Man", Trailer = "https://www.youtube.com/embed/sg_hzT0QhPM" },
            new Pelicula { PeliculaId = 12, GeneroId = 6, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/np12.jpg", Sinopsis = "Este documental de naturaleza, explora la asombrosa belleza y diversidad de la vida en la Tierra. La película muestra lo más sorprendentes del planeta y resalta la importancia de la conservación y la protección de la vida silvestre y los ecosistemas.", Titulo = "Nuestro Planeta", Trailer = "https://www.youtube.com/embed/IrER_EpwGjg" },
            new Pelicula { PeliculaId = 13, GeneroId = 7, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/ll13.jpg", Sinopsis = "La Lista de Schindler está basada en la historia real de Oskar Schindler, un empresario alemán que salvó la vida de más de mil judíos durante el Holocausto al emplearlos en sus fábricas.", Titulo = "La Lista de Schindler", Trailer = "https://www.youtube.com/embed/7q-ETFeMxwI" },
            new Pelicula { PeliculaId = 14, GeneroId = 7, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/rm14.jpg", Sinopsis = "Dirigida por Paulina García, Mujer en Llamas sigue a Ema , una joven bailarina que está decidida a recuperar a su hijo después de que su adopción se rompe.", Titulo = "Mujer en Llamas", Trailer = "https://www.youtube.com/embed/E5w4BaMiC1El" },
            new Pelicula { PeliculaId = 15, GeneroId = 8, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/sa15.jpg", Sinopsis = "Basada en la novela de J.R.R. Tolkien, esta película dirigida por Peter Jackson sigue la épica aventura de Frodo Baggins y un variado grupo de personajes mientras intentan destruir un poderoso anillo que podría sumir al mundo en la oscuridad.", Titulo = "El Señor de los Anillos: La Comunidad del Anillo", Trailer = "https://www.youtube.com/embed/3GJp6p_mgPo" },
            new Pelicula { PeliculaId = 16, GeneroId = 8, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/lb16.jpg", Sinopsis = "El Laberinto del Fauno se desarrolla en la posguerra de España y sigue a Ofelia, una niña que descubre un mundo mágico y misterioso en un laberinto cerca de su nuevo hogar.", Titulo = "El Laberinto del Fauno", Trailer = "https://www.youtube.com/embed/gpEh4O8Hb5Y" },
            new Pelicula { PeliculaId = 17, GeneroId = 9, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/gs17.jpg", Sinopsis = "El Gran Showman narra la historia de cómo Barnum creó el circo que eventualmente se convertiría en el famoso Circo Barnum & Bailey.", Titulo = "El Gran Showman", Trailer = "https://www.youtube.com/embed/uprrVIIT0G8" },
            new Pelicula { PeliculaId = 18, GeneroId = 9, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/lm18.jpg", Sinopsis = "Los Miserables sigue las vidas entrelazadas de varios personajes en la Francia del siglo XIX. La película se centra en la historia de Jean Valjean), un exconvicto que busca redimirse mientras es perseguido por el inspector Javert (Russell Crowe)..", Titulo = "Los Miserables", Trailer = "https://www.youtube.com/embed/EZngbEj3W1Y" },
            new Pelicula { PeliculaId = 19, GeneroId = 10, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/sv19.jpg", Sinopsis = "Dirigida por Jim Gillespie, esta película sigue a un grupo de amigos que, después de un trágico accidente automovilístico en el que atropellan a un hombre, deciden ocultar su crimen y juran guardar el secreto.", Titulo = "Sé lo que Hicieron el Verano Pasado", Trailer = "https://www.youtube.com/embed/_y6H2ybiEvs" },
            new Pelicula { PeliculaId = 20, GeneroId = 10, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/sc20.jpg", Sinopsis = "Basada en la novela de Thomas Harris, esta película presenta a la joven agente del FBI Clarice Starling mientras busca la ayuda del brillante pero psicótico asesino en serie Hannibal Lecter para atrapar a otro asesino en serie conocido como Buffalo Bill.", Titulo = "El Silencio de los Corderos", Trailer = "https://www.youtube.com/embed/3VZa6KAxE1I" },
            new Pelicula { PeliculaId = 21, GeneroId = 11, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/ee21.jpg", Sinopsis = "El Exorcista es un clásico del terror que sigue la historia de Regan, una niña poseída por una entidad demoníaca. La película sigue los esfuerzos de un sacerdote y un psiquiatra para exorcizar al demonio que ha tomado control del cuerpo de la niña.", Titulo = "El Exorcista", Trailer = "https://www.youtube.com/embed/gYApro2YXQQ" },
            new Pelicula { PeliculaId = 22, GeneroId = 11, Poster = "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/ec22.jpg", Sinopsis = "El Conjuro está basada en casos reales de los investigadores paranormales Ed y Lorraine Warren. La película sigue a los Warren ) mientras investigan una serie de eventos sobrenaturales aterradores que ocurren en la casa de una familia.", Titulo = "El Conjuro", Trailer = "https://www.youtube.com/embed/_zU1gLWGnpg" }
            );
        }
    }
}
