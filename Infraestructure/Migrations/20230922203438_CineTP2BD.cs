using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CineTP2BD : Migration
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
                    Sinopsis = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                        principalColumn: "PeliculaId");
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
                    { 1, 1, "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/9/9b/Avenger_Endgame_Poster_Oficial.png/revision/latest?cb=20190326185910&path-prefix=es", "Después de los devastadores eventos ocurridos en Vengadores: Infinity War, el universo está en ruinas debido a las acciones de Thanos, el Titán Loco. Tras la derrota, las cosas no pintan bien para los Vengadores. Mientras Iron Man vaga en soledad junto a Nebula en una nave lejos de la Tierra, el grupo encabezado por Capitán América, Viuda Negra, Hulk y Thor deberá tratar de revertir los efectos de la catástrofe provocada por Thanos. Los Vengadores deberán reunirse una vez más para deshacer sus acciones y restaurar el orden en el universo de una vez por todas. Esta vez, contarán también con aliados como Ojo de Halcón y Capitana Marvel, además de Ant-Man, que presumiblemente podría haber estado atrapado en el Reino Cuántico. Juntos, se prepararán para la batalla final, sin importar cuáles sean las consecuencias.", "Avengers: End Game", "https://www.youtube.com/watch?v=PyakRSni-c0" },
                    { 2, 1, "https://images.justwatch.com/poster/99741292/s718/los-vengadores-infinity-war.jpg", "Un nuevo peligro acecha procedente de las sombras del cosmos. Thanos, el infame tirano intergaláctico, tiene como objetivo reunir las seis Gemas del Infinito, artefactos de poder inimaginable, y usarlas para imponer su perversa voluntad a toda la existencia. Los Vengadores y sus aliados tendrán que luchar contra el mayor villano al que se han enfrentado nunca, y evitar que se haga con el control de la galaxia. En su nueva e impactante aventura, el destino de la Tierra nunca había sido más incierto, las Gemas del Infinito estarán en juego, unos querrán protegerlas y otros controlarlas, ¿quién ganará?", "Avengers: Infinity War", "https://www.youtube.com/watch?v=823iAZOEKt8" },
                    { 3, 2, "https://static.wikia.nocookie.net/cine/images/6/62/Piratas_del_Caribe.jpg/revision/latest?cb=20201006154235", "El capitán Jack Sparrow (interpretado por Johnny Depp) se embarca en una trepidante aventura para recuperar su querido barco, el Perla Negra, que ha sido robado por su rival, el capitán Barbossa. Sin embargo, Sparrow no solo busca recuperar su barco, sino también enfrentarse a una maldición que afecta a la tripulación de Barbossa, convirtiéndolos en inmortales pero condenados a ser esqueletos durante la noche. Con la ayuda de la valiente Elizabeth Swann (Keira Knightley) y el temerario Will Turner (Orlando)", "Piratas del Caribe: La Maldición del Perla Negra", "https://www.youtube.com/watch?v=5Itr2jHuJaw" },
                    { 4, 2, "https://static.wikia.nocookie.net/cine/images/a/a2/IndianaJonesLostArk.jpg/revision/latest?cb=20121009224059", "El arqueólogo y aventurero Indiana Jones (interpretado por Harrison Ford) es reclutado por el gobierno de los Estados Unidos para encontrar el Arca de la Alianza antes de que los nazis lo hagan. Según la leyenda, el Arca contiene poderes sobrenaturales y puede ser utilizada como arma devastadora. Indiana Jones se embarca en una emocionante búsqueda que lo lleva a lugares exóticos y peligrosos alrededor del mundo. A lo largo de su viaje, se enfrenta a trampas mortales, enemigos despiadados y situaciones de suspenso constante mientras lucha por mantener el Arca fuera del alcance de los nazis y preservar su importancia histórica.", "Indiana Jones y los Cazadores del Arca Perdida", "https://www.youtube.com/watch?v=ceMf9xtDA6U" },
                    { 5, 3, "https://pics.filmaffinity.com/Interstellar-366875261-large.jpg", "En un futuro donde la Tierra se enfrenta a la escasez de recursos y la decadencia ambiental, un grupo de exploradores espaciales liderados por el piloto Cooper (interpretado por Matthew McConaughey) se embarca en una misión interestelar para encontrar un nuevo hogar para la humanidad. Utilizando agujeros de gusano recientemente descubiertos, viajan a través del espacio en busca de un planeta habitable. La película explora conceptos de gravedad, dimensiones alternativas y la lucha por la supervivencia humana en un entorno alienígena.", "Interestelar", "https://www.youtube.com/watch?v=LYS2O1nl9iM" },
                    { 6, 3, "https://cloudfront-us-east-1.images.arcpublishing.com/artear/CSTSFCSG35DQNFZVORM4DLQCIU.jpg", "Drama biográfico de corte histórico basado en American Prometheus, la biografía escrita por Kai Bird y Martin J. Sherwin en torno a la figura del científico J. Robert Oppenheimer y su rol en la creación y desarrollo de la bomba atómica. 16 de julio de 1945, en el desierto de Nuevo México se detona en secreto la primera bomba atómica. En tiempos de guerra, el brillante físico estadounidense Julius Robert Oppenheimer (Cillian Murphy), al frente del proyecto Manhattan, lidera los ensayos nucleares para construir la bomba atómica para su país.", "OppenHeimer", "https://www.youtube.com/watch?v=MVvGSBKV504" },
                    { 7, 4, "https://pics.filmaffinity.com/Origen-652954101-large.jpg", "Dirigida por Christopher Nolan, Origen sigue a Dom Cobb (interpretado por Leonardo DiCaprio), un ladrón habilidoso que se especializa en el robo de secretos a través de la invasión de los sueños de otras personas. Sin embargo, su última misión implica la tarea inversa: implantar una idea en la mente de alguien. La película explora temas de la realidad, la percepción y los límites de la mente humana a medida que el equipo de Cobb se sumerge cada vez más en niveles profundos de sueños.", "Origen", "https://www.youtube.com/watch?v=RV9L7ui9Cn8" },
                    { 8, 4, "https://pics.filmaffinity.com/Matrix-155050517-large.jpg", "Dirigida por los hermanos Wachowski, Matrix presenta a Thomas Anderson (interpretado por Keanu Reeves), un programador de software que, bajo el alias de Neo, se une a un grupo de rebeldes que luchan contra una inteligencia artificial que ha esclavizado a la humanidad en una realidad simulada llamada la Matriz. La película combina acción, filosofía y conceptos de simulación virtual para crear una historia única sobre la búsqueda de la verdad y la liberación de la mente humana.", "Matrix", "https://www.youtube.com/watch?v=sMkNB8v-0uQ" },
                    { 9, 5, "https://static.wikia.nocookie.net/doblaje/images/5/50/MiPobreAngelito.jpg/revision/latest?cb=20150517192150&path-prefix=es", "Kevin McCallister (interpretado por Macaulay Culkin) es un niño de ocho años que es accidentalmente dejado atrás cuando su familia se va de vacaciones durante la Navidad. Mientras se encuentra solo en casa, Kevin debe defender su hogar de dos torpes ladrones que intentan robarlo. La película es una mezcla de humor físico y situaciones cómicas mientras Kevin utiliza su ingenio para crear elaboradas trampas y hacer que los ladrones paguen por sus acciones.", "Mi Pobre Angelito", "https://www.youtube.com/watch?v=KSpCNBIo92A" },
                    { 10, 5, "https://pics.filmaffinity.com/Supersalidos-743461969-large.jpg", "Dos amigos de preparatoria, Seth (interpretado por Jonah Hill) y Evan (Michael Cera), están a punto de graduarse y enfrentan la realidad de que sus caminos podrían separarse. Deciden asistir a una fiesta con la esperanza de perder su virginidad antes de la graduación. La película sigue sus hilarantes desventuras mientras intentan conseguir alcohol, lidiar con situaciones incómodas y mantener su amistad en medio del caos.", "Superbad", "https://www.youtube.com/watch?v=au2Zq8D9RaY" },
                    { 11, 6, "https://es.web.img3.acsta.net/medias/nmedia/18/95/26/08/20393348.jpg", "Dirigida por Malik Bendjelloul, Buscando a Sugar Man narra la historia de Sixto Rodríguez, un músico folk estadounidense que, a pesar de no haber tenido éxito comercial en su propio país, se convirtió en una leyenda musical en Sudáfrica durante los años 70. La película sigue a dos aficionados sudafricanos de la música que se embarcan en una búsqueda para descubrir qué sucedió realmente con Rodríguez y cuál fue su destino después de su breve carrera en la industria musical. A medida que desentrañan la verdad, descubren una historia increíble de música, misterio y redescubrimiento.", "Buscando a Sugar Man", "https://www.youtube.com/watch?v=sg_hzT0QhPM" },
                    { 12, 6, "https://pics.filmaffinity.com/Nuestro_planeta_Serie_de_TV-955486466-large.jpg", "Esta serie documental de naturaleza, narrada por David Attenborough, explora la asombrosa belleza y diversidad de la vida en la Tierra. A lo largo de varios episodios, la serie muestra los hábitats naturales más sorprendentes del planeta y resalta la importancia de la conservación y la protección de la vida silvestre y los ecosistemas.", "Nuestro Planeta", "https://www.youtube.com/watch?v=IrER_EpwGjg" },
                    { 13, 7, "https://pics.filmaffinity.com/La_lista_de_Schindler-473662617-large.jpg", " Dirigida por Steven Spielberg, La Lista de Schindler está basada en la historia real de Oskar Schindler (interpretado por Liam Neeson), un empresario alemán que salvó la vida de más de mil judíos durante el Holocausto al emplearlos en sus fábricas. La película sigue su evolución desde un oportunista empresario hasta un héroe que arriesga todo para proteger a aquellos perseguidos por el régimen nazi. Es una historia poderosa que muestra tanto la oscuridad de la historia como la capacidad del espíritu humano para resistir y mostrar compasión.", "La Lista de Schindler", "https://www.youtube.com/watch?v=7q-ETFeMxwI" },
                    { 14, 7, "https://es.web.img3.acsta.net/pictures/19/09/04/11/42/1166515.jpg", "Dirigida por Paulina García, Mujer en Llamas sigue a Ema (interpretada por Mariana Di Girolamo), una joven bailarina que está decidida a recuperar a su hijo después de que su adopción se rompe. La película explora temas de amor, maternidad, arrepentimiento y búsqueda de identidad mientras Ema desafía convenciones sociales y emprende un viaje emocional y físico para recuperar a su hijo.", "Mujer en Llamas", "https://www.filmaffinity.com/es/film218131.html" },
                    { 15, 8, "https://play-lh.googleusercontent.com/imeAs3_Nb9fyoj56LgLzSRBs3UXTZTH_TLg2xMkg6J90ZPzxscAXPvtsR9Q9azxe-WCy5A", "Basada en la novela de J.R.R. Tolkien, esta película dirigida por Peter Jackson sigue la épica aventura de Frodo Baggins (interpretado por Elijah Wood) y un variado grupo de personajes mientras intentan destruir un poderoso anillo que podría sumir al mundo en la oscuridad. Ambientada en un mundo de fantasía llamado la Tierra Media, la película presenta criaturas míticas, paisajes impresionantes y una historia de valentía y amistad mientras la Comunidad del Anillo lucha contra fuerzas oscuras para salvar a su mundo.", "El Señor de los Anillos: La Comunidad del Anillo", "https://www.youtube.com/watch?v=3GJp6p_mgPo" },
                    { 16, 8, "https://images-na.ssl-images-amazon.com/images/S/pv-target-images/5ea3b0f74fe2901a697365e20b15ac3accdcf68365f9db9aa039f07ae5368165._RI_TTW_.jpg", " Dirigida por Guillermo del Toro, El Laberinto del Fauno se desarrolla en la posguerra de España y sigue a Ofelia (interpretada por Ivana Baquero), una niña que descubre un mundo mágico y misterioso en un laberinto cerca de su nuevo hogar. Mientras su madre embarazada se enfrenta a dificultades y su padrastro brutal busca eliminar a los rebeldes locales, Ofelia se encuentra en una serie de desafíos mágicos y oscuros que la llevan a cuestionar la realidad y la fantasía.", "El Laberinto del Fauno", "https://www.youtube.com/watch?v=gpEh4O8Hb5Y" },
                    { 17, 9, "https://www.lavanguardia.com/peliculas-series/images/movie/poster/2017/12/w1280/4ssLEvNQ5oM9sJnV6FkDVgOtyAE.jpg", "Inspirada en la vida de P.T. Barnum, El Gran Showman narra la historia de cómo Barnum (interpretado por Hugh Jackman) creó el circo que eventualmente se convertiría en el famoso Circo Barnum & Bailey. La película combina elementos de música, baile y espectáculo con temas de ambición, amor y aceptación mientras Barnum lucha por encontrar el éxito y la aceptación social.", "El Gran Showman", "https://www.youtube.com/watch?v=uprrVIIT0G8" },
                    { 18, 9, "https://pics.filmaffinity.com/Los_miserables-196100834-large.jpg", "Basada en la novela clásica de Victor Hugo, Los Miserables sigue las vidas entrelazadas de varios personajes en la Francia del siglo XIX. La película se centra en la historia de Jean Valjean (interpretado por Hugh Jackman), un exconvicto que busca redimirse mientras es perseguido por el inspector Javert (Russell Crowe). La película está llena de canciones emotivas y poderosas que exploran temas de justicia, amor y sacrificio.", "Los Miserables", "https://www.youtube.com/watch?v=EZngbEj3W1Y" },
                    { 19, 10, "https://static.wikia.nocookie.net/doblaje/images/5/57/Se_lo_que_icieron_el_verano.png/revision/latest?cb=20130228060651&path-prefix=es", "Dirigida por Jim Gillespie, esta película sigue a un grupo de amigos que, después de un trágico accidente automovilístico en el que atropellan a un hombre, deciden ocultar su crimen y juran guardar el secreto. Un año después, comienzan a recibir amenazantes mensajes que los persiguen con la pregunta: ¿Sabes lo que hicieron el verano pasado?. La película se convierte en un juego de suspense mientras los protagonistas luchan por descubrir la verdad detrás de los mensajes y enfrentan las consecuencias de sus acciones.", "Sé lo que Hicieron el Verano Pasado", "https://www.youtube.com/watch?v=_y6H2ybiEvs" },
                    { 20, 10, "https://es.web.img3.acsta.net/medias/nmedia/18/74/29/15/19757760.jpg", "Basada en la novela de Thomas Harris, esta película dirigida por Jonathan Demme presenta a la joven agente del FBI Clarice Starling (interpretada por Jodie Foster) mientras busca la ayuda del brillante pero psicótico asesino en serie Hannibal Lecter (Anthony Hopkins) para atrapar a otro asesino en serie conocido como Buffalo Bill. La película es una mezcla de suspense psicológico y drama policial, y se centra en la relación entre Starling y Lecter mientras persiguen a un asesino extremadamente peligroso.", "El Silencio de los Corderos", "https://www.youtube.com/watch?v=3VZa6KAxE1I" },
                    { 21, 11, "https://r1.abcimg.es/resizer/resizer.php?imagen=https%3A%2F%2Fs1.abcstatics.com%2Fmedia%2Fpeliculas%2F000%2F002%2F487%2Fel-exorcista-1.jpg&nuevoancho=683&medio=abc", "Dirigida por William Friedkin, El Exorcista es un clásico del terror que sigue la historia de Regan (interpretada por Linda Blair), una niña poseída por una entidad demoníaca. La película sigue los esfuerzos de un sacerdote y un psiquiatra para exorcizar al demonio que ha tomado control del cuerpo de la niña.El Exorcista es conocida por sus escenas intensas y perturbadoras, y se ha convertido en una película icónica del género de terror.", "El Exorcista", "https://www.youtube.com/watch?v=gYApro2YXQQ" },
                    { 22, 11, "https://static.wikia.nocookie.net/doblaje/images/e/eb/ElConjuroPoster.jpg/revision/latest?cb=20170907214450&path-prefix=es", "Dirigida por James Wan, El Conjuro está basada en casos reales de los investigadores paranormales Ed y Lorraine Warren. La película sigue a los Warren (interpretados por Patrick Wilson y Vera Farmiga) mientras investigan una serie de eventos sobrenaturales aterradores que ocurren en la casa de una familia. La película crea una atmósfera de miedo y tensión a medida que los personajes enfrentan fuerzas malévolas y luchan por proteger a la familia de las fuerzas sobrenaturales.", "El Conjuro", "https://www.youtube.com/watch?v=_zU1gLWGnpg" }
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
