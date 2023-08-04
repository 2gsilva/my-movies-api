using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using my_movies_api.Models.Commands.Requests;
using my_movies_api.Models.Handlers.Interfaces.Handlers;

namespace my_movies_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ICreateMovieHandler _handler; 

        public MoviesController(ICreateMovieHandler handler) 
        {
            _handler = handler;
        }

        [HttpPost]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] CreateMovieRequest command)
        {
            var response = _handler.Handle(command);

          return Created("", response);  
        }
    }
}
