using CinemaProject.Domain.DomainModels;
using CinemaProject.Repository.Interface;
using CinemaProject.Service.Interface;
using System;
using System.Collections.Generic;

namespace CinemaProject.Service.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie AddMovie(Movie entity)
        {
            return _movieRepository.Insert(entity);
        }

        public Movie DeleteMovie(Movie entity)
        {
            return _movieRepository.Delete(entity);
        }

        public IEnumerable<Movie> FindAllMovies()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetMovieById(Guid? id)
        {
            return _movieRepository.Get(id);
        }

        public bool MovieExists(Guid id)
        {
            return GetMovieById(id) != null;
        }

        public Movie UpdateMovie(Movie entity)
        {
            return _movieRepository.Update(entity);
        }
    }
}
