using Commands.Handlers.Interfaces;
using Commands.Requests;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Querys.Handlers.Interfaces;

namespace my_movies_api.Controllers
{
    [Route("api")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteQueryHandler _queryHandle;
        private readonly IFavoriteCommandHandler _commandHandle;

        public FavoriteController(
            IFavoriteQueryHandler queryHandle,
            IFavoriteCommandHandler commandHandle
            )
        {
            _queryHandle = queryHandle;
            _commandHandle = commandHandle;
        }

        [HttpGet]
        [Route("v1/favorites")]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var response = await _queryHandle.GetFavorites();

            if (!response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpPost]
        [Route("v1/favorites")]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] FavoriteRequest favorite)
        {
            if (!ModelState.IsValid)
                BadRequest();

            await _commandHandle.AddFavorite(favorite);

            return Created(string.Empty, new { message = "Filme adicionado aos favoritos!" });
        }
    }
}
