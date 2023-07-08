using System.Collections.Generic;
using System;
using CinemaProject.Domain.DomainModels;

namespace CinemaProject.Service.Interface
{
    public interface IMovieService
    {
        IEnumerable<Movie> FindAllMovies();
        Movie GetMovieById(Guid? id);
        Movie AddMovie(Movie entity);
        Movie UpdateMovie(Movie entity);
        Movie DeleteMovie(Movie entity);
        bool MovieExists(Guid id);
    }
}
