﻿namespace my_movies_api.Models.Domains
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}