using Microsoft.EntityFrameworkCore;
using my_movies_api.Data;
using my_movies_api.Data.Cachings;
using my_movies_api.Data.Repositories;
using my_movies_api.Models._3.Handlers;
using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._1.Handlers;
using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._2.Repositories;
using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._3.Services;
using my_movies_api.Models.Handlers;
using my_movies_api.Models.Handlers.Interfaces.Handlers;
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

builder.Services
    .AddScoped<ICreateMovieHandler, CreateMovieHandler>()
    .AddScoped<IGetMoviesHandler, GetMoviesHandler>()
    .AddScoped<IMovieRepository, MovieRepository>()
    .AddScoped<IMoviesService, MoviesService>()
    .AddScoped<IMovieCaching, MovieCaching>()
    .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
    .AddScoped<HttpClient>()
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