using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._1.Handlers;
using my_movies_api.Models.Commands.Requests;
using my_movies_api.Models.Handlers.Interfaces.Handlers;

namespace my_movies_api.Controllers
{
    [Route("api")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ICreateMovieHandler _create;
        private readonly IGetMoviesHandler _get; 

        public MoviesController(ICreateMovieHandler create, IGetMoviesHandler get) 
        {
            _create = create;
            _get = get;
        }

        [HttpPost]
        [Route("v1/movies")]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] CreateMovieRequest command)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var response = _create.Handle(command);

          return Created("", response);  
        }

        [HttpGet]
        [Route("v1/movies")]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            var response = _get.Handle();

            if(!response.Any())
                return NoContent();

            return Ok(response);
        }
    }
}
