using Application.Interfaces;
using Application.Mappers;
using Application.UseCases;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<CineBD>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IFuncionService, FuncionService>();
builder.Services.AddScoped<IFuncionCommand, FuncionCommand>();
builder.Services.AddScoped<IFuncionQuery, FuncionQuery>();
builder.Services.AddScoped<IFuncionMapper, FuncionMapper>();


builder.Services.AddScoped<IPeliculaService, PeliculaService>();
builder.Services.AddScoped<IPeliculaQuery, PeliculaQuery>();
builder.Services.AddScoped<IPeliculaCommand, PeliculaCommand>();
builder.Services.AddScoped<IPeliculaMapper, PeliculaMapper>();

builder.Services.AddScoped<ISalaService, SalaService>();
builder.Services.AddScoped<ISalaQuery, SalaQuery>();
builder.Services.AddScoped<ISalaMapper, SalaMapper>();

builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketQuery, TicketQuery>();
builder.Services.AddScoped<ITicketCommand, TicketCommand>();
builder.Services.AddScoped<ITicketMapper, TicketMapper>();

builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<IGeneroQuery, GeneroQuery>();
builder.Services.AddScoped<IGeneroMapper, GeneroMapper>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
