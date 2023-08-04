using Microsoft.EntityFrameworkCore;
using my_movies_api.Data;
using my_movies_api.Data.Repositories;
using my_movies_api.Models._3.Handlers._3._1.Interfaces._3._1._2.Repositories;
using my_movies_api.Models.Handlers;
using my_movies_api.Models.Handlers.Interfaces.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// dependency injection
builder.Services.AddScoped<MovieRepository>();

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
    .AddScoped<IMovieRepository, MovieRepository>()
    .AddDbContext<MovieContext>(opt => opt.UseInMemoryDatabase("MovieDb"));

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