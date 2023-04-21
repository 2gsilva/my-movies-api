using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using my_movies_api.Repositories;

namespace my_movies_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieRepository _repository; 

        public MoviesController(MovieRepository repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            var movies = _repository.GetAll();

          return Ok(movies);  
        }
    }
}
