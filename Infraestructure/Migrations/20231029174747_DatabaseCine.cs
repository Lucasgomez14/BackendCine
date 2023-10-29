using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId");
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId");
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GeneroId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acción" },
                    { 2, "Aventura" },
                    { 3, "Ciencia" },
                    { 4, "Ficción" },
                    { 5, "Comedia" },
                    { 6, "Documental" },
                    { 7, "Drama" },
                    { 8, "Fantasía" },
                    { 9, "Musical" },
                    { 10, "Suspense" },
                    { 11, "Terror" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad", "Nombre" },
                values: new object[,]
                {
                    { 1, 5, "Sala 1" },
                    { 2, 15, "Sala 2" },
                    { 3, 35, "Sala 3" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "GeneroId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, 1, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/aeg2.jpg", "Después de los devastadores eventos ocurridos en Vengadores: Infinity War, el universo está en ruinas debido a las acciones de Thanos, el Titán Loco. Tras la derrota, las cosas no pintan bien para los Vengadores.", "Avengers: End Game", "https://www.youtube.com/embed/PyakRSni-c0" },
                    { 2, 1, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/aiw2.jpg", "Un nuevo peligro acecha procedente de las sombras del cosmos. Thanos, el infame tirano intergaláctico, tiene como objetivo reunir las seis Gemas del Infinito y usarlas para imponer su perversa voluntad a toda la existencia.", "Avengers: Infinity War", "https://www.youtube.com/embed/823iAZOEKt8" },
                    { 3, 2, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/pc3.jpg", "El capitán Jack Sparrow se embarca en una trepidante aventura para recuperar su querido barco, el Perla Negra, que ha sido robado por su rival, el capitán Barbossa.", "Piratas del Caribe: La Maldición del Perla Negra", "https://www.youtube.com/embed/5Itr2jHuJaw" },
                    { 4, 2, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/ij4.jpg", "El arqueólogo y aventurero Indiana Jones (interpretado por Harrison Ford) es reclutado por el gobierno de los Estados Unidos para encontrar el Arca de la Alianza antes de que los nazis lo hagan.", "Indiana Jones y los Cazadores del Arca Perdida", "https://www.youtube.com/embed/ceMf9xtDA6U" },
                    { 5, 3, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/is5.jpg", "En un futuro donde la Tierra se enfrenta a la escasez de recursos y la decadencia ambiental, un grupo de exploradores espaciales liderados por el piloto Cooperse embarca en una misión interestelar para encontrar un nuevo hogar para la humanidad.", "Interestelar", "https://www.youtube.com/embed/LYS2O1nl9iM" },
                    { 6, 3, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/op6.jpg", "En tiempos de guerra, el brillante físico estadounidense Julius Robert Oppenheimer, al frente del proyecto Manhattan, lidera los ensayos nucleares para construir la bomba atómica para su país.", "OppenHeimer", "https://www.youtube.com/embed/MVvGSBKV504" },
                    { 7, 4, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/or7.jpg", "Origen sigue a Dom Cobb, un ladrón habilidoso que se especializa en el robo de secretos a través de la invasión de los sueños de otras personas. Sin embargo, su última misión implica la tarea inversa: implantar una idea en la mente de alguien.", "Origen", "https://www.youtube.com/embed/RV9L7ui9Cn8" },
                    { 8, 4, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/ma8.jpg", "Matrix presenta a Neo, un programador de software que, se une a un grupo de rebeldes que luchan contra una inteligencia artificial que ha esclavizado a la humanidad en una realidad simulada llamada la Matriz.", "Matrix", "https://www.youtube.com/embed/sMkNB8v-0uQ" },
                    { 9, 5, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/pa9.jpg", "Kevin McCallister es un niño de ocho años que es accidentalmente dejado atrás cuando su familia se va de vacaciones durante la Navidad. Mientras se encuentra solo en casa, Kevin debe defender su hogar de dos torpes ladrones que intentan robarlo.", "Mi Pobre Angelito", "https://www.youtube.com/embed/KSpCNBIo92A" },
                    { 10, 5, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/sb10.jpg", "Dos amigos de preparatoria, Seth y Evan, están a punto de graduarse y enfrentan la realidad de que sus caminos podrían separarse. Deciden asistir a una fiesta con la esperanza de perder su virginidad antes de la graduación.", "Superbad", "https://www.youtube.com/embed/au2Zq8D9RaY" },
                    { 11, 6, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/sm11.jpg", "Buscando a Sugar Man narra la historia de Sixto Rodríguez, un músico folk estadounidense que, a pesar de no haber tenido éxito comercial en su propio país, se convirtió en una leyenda musical en Sudáfrica durante los años 70.", "Buscando a Sugar Man", "https://www.youtube.com/embed/sg_hzT0QhPM" },
                    { 12, 6, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/np12.jpg", "Este documental de naturaleza, explora la asombrosa belleza y diversidad de la vida en la Tierra. La película muestra lo más sorprendentes del planeta y resalta la importancia de la conservación y la protección de la vida silvestre y los ecosistemas.", "Nuestro Planeta", "https://www.youtube.com/embed/IrER_EpwGjg" },
                    { 13, 7, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/ll13.jpg", "La Lista de Schindler está basada en la historia real de Oskar Schindler, un empresario alemán que salvó la vida de más de mil judíos durante el Holocausto al emplearlos en sus fábricas.", "La Lista de Schindler", "https://www.youtube.com/embed/7q-ETFeMxwI" },
                    { 14, 7, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/rm14.jpg", "Dirigida por Paulina García, Mujer en Llamas sigue a Ema , una joven bailarina que está decidida a recuperar a su hijo después de que su adopción se rompe.", "Mujer en Llamas", "https://www.youtube.com/embed/E5w4BaMiC1El" },
                    { 15, 8, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/sa15.jpg", "Basada en la novela de J.R.R. Tolkien, esta película dirigida por Peter Jackson sigue la épica aventura de Frodo Baggins y un variado grupo de personajes mientras intentan destruir un poderoso anillo que podría sumir al mundo en la oscuridad.", "El Señor de los Anillos: La Comunidad del Anillo", "https://www.youtube.com/embed/3GJp6p_mgPo" },
                    { 16, 8, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/lb16.jpg", "El Laberinto del Fauno se desarrolla en la posguerra de España y sigue a Ofelia, una niña que descubre un mundo mágico y misterioso en un laberinto cerca de su nuevo hogar.", "El Laberinto del Fauno", "https://www.youtube.com/embed/gpEh4O8Hb5Y" },
                    { 17, 9, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/gs17.jpg", "El Gran Showman narra la historia de cómo Barnum creó el circo que eventualmente se convertiría en el famoso Circo Barnum & Bailey.", "El Gran Showman", "https://www.youtube.com/embed/uprrVIIT0G8" },
                    { 18, 9, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/lm18.jpg", "Los Miserables sigue las vidas entrelazadas de varios personajes en la Francia del siglo XIX. La película se centra en la historia de Jean Valjean), un exconvicto que busca redimirse mientras es perseguido por el inspector Javert (Russell Crowe)..", "Los Miserables", "https://www.youtube.com/embed/EZngbEj3W1Y" },
                    { 19, 10, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/sv19.jpg", "Dirigida por Jim Gillespie, esta película sigue a un grupo de amigos que, después de un trágico accidente automovilístico en el que atropellan a un hombre, deciden ocultar su crimen y juran guardar el secreto.", "Sé lo que Hicieron el Verano Pasado", "https://www.youtube.com/embed/_y6H2ybiEvs" },
                    { 20, 10, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/sc20.jpg", "Basada en la novela de Thomas Harris, esta película presenta a la joven agente del FBI Clarice Starling mientras busca la ayuda del brillante pero psicótico asesino en serie Hannibal Lecter para atrapar a otro asesino en serie conocido como Buffalo Bill.", "El Silencio de los Corderos", "https://www.youtube.com/embed/3VZa6KAxE1I" },
                    { 21, 11, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/ee21.jpg", "El Exorcista es un clásico del terror que sigue la historia de Regan, una niña poseída por una entidad demoníaca. La película sigue los esfuerzos de un sacerdote y un psiquiatra para exorcizar al demonio que ha tomado control del cuerpo de la niña.", "El Exorcista", "https://www.youtube.com/embed/gYApro2YXQQ" },
                    { 22, 11, "https://raw.githubusercontent.com/Lucasgomez14/complementosImagenes/main/imagenesTP3/ec22.jpg", "El Conjuro está basada en casos reales de los investigadores paranormales Ed y Lorraine Warren. La película sigue a los Warren ) mientras investigan una serie de eventos sobrenaturales aterradores que ocurren en la casa de una familia.", "El Conjuro", "https://www.youtube.com/embed/_zU1gLWGnpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_GeneroId",
                table: "Peliculas",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
