using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._1.Handlers;

namespace my_movies_api.Controllers
{
    [Route("api")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IGetMoviesHandler _get; 

        public MoviesController(IGetMoviesHandler get) 
        {
            _get = get;
        }
                
        [HttpGet]
        [Route("v1/movies/{movie}")]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string movie)
        {
            var response = await _get.Handle(movie);

            if (response is null)
                return NoContent();

            return Ok(response);
        }
    }
}
