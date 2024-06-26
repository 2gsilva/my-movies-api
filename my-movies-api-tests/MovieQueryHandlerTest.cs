using Moq;
using my_movies_api.Data.Cachings.Interfaces;
using my_movies_api.Models.Domains;
using my_movies_api.Models.Interfaces.Services;
using my_movies_api.Models.Querys.Handlers;
using my_movies_api_tests.Mocks;
using System.Reflection;

namespace my_movies_api_tests
{
    public class MovieQueryHandlerTest
    {
        private readonly Mock<IMoviesService> _movieServiceMock;
        private readonly Mock<IMovieCaching> _cacheMock;
        private readonly MovieQueryHandler _movieHendler;

        public MovieQueryHandlerTest()
        {
            _movieServiceMock = new Mock<IMoviesService>();
            _cacheMock = new Mock<IMovieCaching>();

            _movieHendler = new MovieQueryHandler(
                _movieServiceMock.Object,
                _cacheMock.Object
            );
        }

        [Fact]
        public async Task GetMovies_SemCacheBuscandoDoServico_RetornaColecaoDeFilmes()
        {
            // Arrange
            _cacheMock.Setup(e => e.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<string>());

            _cacheMock.Setup(e => e.SetAsync(It.IsAny<string>(), It.IsAny<string>()));

            _movieServiceMock.Setup(e => e.GetMovie(It.IsAny<string>()))
                .ReturnsAsync(MovieMock.GetMovie);
            
            // Act
            await _movieHendler.GetMovies(It.IsAny<string>());

            // Assert
            _cacheMock.Verify(e => e.GetAsync(It.IsAny<string>()), Times.Once);
            _cacheMock.Verify(e => e.SetAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            _movieServiceMock.Verify(e => e.GetMovie(It.IsAny<string>()), Times.Once);
        }
    }
}