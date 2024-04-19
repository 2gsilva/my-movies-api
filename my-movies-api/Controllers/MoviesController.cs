using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using my_movies_api.Models.Querys.Handlers.Interfaces;

namespace my_movies_api.Controllers
{
    [Route("api")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieQueryHandler _movieHandler; 

        public MoviesController(IMovieQueryHandler movieHandler) 
        {
            _movieHandler = movieHandler;
        }
                
        [HttpGet]
        [Route("v1/movies/{movie}")]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string movie)
        {
            var response = await _movieHandler.GetMovies(movie);

            if (!response.Any())
                return NoContent();

            return Ok(response);
        }
    }
}
