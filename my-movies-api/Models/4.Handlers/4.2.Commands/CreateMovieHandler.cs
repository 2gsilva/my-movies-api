﻿using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._2.Repositories;
using my_movies_api.Models.Commands.Requests;
using my_movies_api.Models.Commands.Responses;
using my_movies_api.Models.Domains;
using my_movies_api.Models.Handlers.Interfaces.Handlers;

namespace my_movies_api.Models.Handlers
{
    public class CreateMovieHandler : ICreateMovieHandler
    {
        private readonly IMovieRepository _repository;

        public CreateMovieHandler(
            IMovieRepository repository
        )
        {
            _repository = repository;
        }
    }
}
