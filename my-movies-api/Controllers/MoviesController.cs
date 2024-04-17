using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using my_movies_api.Models.Handlers.Interfaces.Handlers;

namespace my_movies_api.Controllers
{
    [Route("api")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IGetMoviesHandler _getMoviesHandler; 

        public MoviesController(IGetMoviesHandler getMoviesHandler) 
        {
            _getMoviesHandler = getMoviesHandler;
        }
                
        [HttpGet]
        [Route("v1/movies/{movie}")]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string movie)
        {
            var response = await _getMoviesHandler.Handle(movie);

            if (response is null)
                return NoContent();

            return Ok(response);
        }
    }
}
