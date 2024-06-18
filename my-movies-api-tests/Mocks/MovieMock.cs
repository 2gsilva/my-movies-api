using my_movies_api.Models.Domains;

namespace my_movies_api_tests.Mocks
{
    public static class MovieMock
    {
        public static Movie GetMovie() 
        {
            var search = new List<Search>();

            search.Add(new Search 
            {
                Id = "1",
                Title = "Simpsons",
                Year = "1900",
                Poster = string.Empty
            });

            search.Add(new Search 
            {
                Id = "2",
                Title = "Pelé Eterno",
                Year = "1900",
                Poster = string.Empty
            });

            return new Movie 
            {
                Response = "true",
                Search = search,
                TotalResults = search.Count.ToString()
            };
        }
    }
}
