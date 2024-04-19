using Microsoft.EntityFrameworkCore;
using my_movies_api.Data;
using my_movies_api.Data.Cachings;
using my_movies_api.Data.Cachings.Interfaces;
using my_movies_api.Data.Repositories;
using my_movies_api.Models.Commands.Handlers;
using my_movies_api.Models.Commands.Handlers.Interfaces;
using my_movies_api.Models.Interfaces.Repositories;
using my_movies_api.Models.Interfaces.Services;
using my_movies_api.Models.Querys.Handlers;
using my_movies_api.Models.Querys.Handlers.Interfaces;
using my_movies_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        policy =>
        {
            policy
                // Origens específicas
                //.WithOrigins(
                //"http://localhost:3000",
                //"https://localhost:3000"
                //)

            // Qualquer origem
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
});
builder.Services.AddMvc();

// Injeção de Dependência
builder.Services
    .AddScoped<ISearchRepository, SearchRepository>()
    .AddScoped<IFavoriteRepository, FavoriteRepository>()
    .AddScoped<IMoviesService, MoviesService>()
    .AddScoped<IMovieCaching, MovieCaching>()
    .AddScoped<IMovieQueryHandler, MovieQueryHandler>()
    .AddScoped<IFavoriteQueryHandler, FavoriteQueryHandler>()
    .AddScoped<IFavoriteCommandHandler, FavoriteCommandHandler>()
    .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
    .AddScoped<HttpClient>();

// Conf Cache
    builder.Services
    .AddDbContext<MovieContext>(opt => opt.UseInMemoryDatabase("MovieDb"))
    .AddStackExchangeRedisCache(e => 
    {
        e.InstanceName = "instance";
        e.Configuration = "172.26.128.1:6379";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI();

// Permitir qualquer origem
app.UseCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Permitir origens específicas
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();