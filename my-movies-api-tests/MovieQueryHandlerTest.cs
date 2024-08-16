using AutoMapper;
using Moq;
using my_movies_api.Domain.Models.Interfaces.Services;
using my_movies_api.Infrastructure.Data.Cachings.Interfaces;
using my_movies_api_tests.Mocks;
using Querys.Handlers;

namespace my_movies_api_tests
{
    public class MovieQueryHandlerTest
    {
        private readonly Mock<IMoviesService> _movieServiceMock;
        private readonly Mock<IMovieCaching> _cacheMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly MovieQueryHandler _movieHendler;

        public MovieQueryHandlerTest()
        {
            _movieServiceMock = new Mock<IMoviesService>();
            _cacheMock = new Mock<IMovieCaching>();
            _mapperMock = new Mock<IMapper>();

            _movieHendler = new MovieQueryHandler(
                _movieServiceMock.Object,
                _cacheMock.Object,
                _mapperMock.Object
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