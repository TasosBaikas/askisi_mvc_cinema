using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace askisi_mvc_cinema.Repositories
{
    using askisi_mvc_cinema.Models;

    public class MovieRepository
    {
        private readonly YourDbContext _dbContext;

        public MovieRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MovieModel> GetAllMovies()
        {
            return _dbContext.MovieModel.ToList();
        }

        public MovieModel GetMovieById(int id)
        {
            return _dbContext.MovieModel.FirstOrDefault(m => m.ID == id);
        }

        public void AddMovie(MovieModel movie)
        {
            _dbContext.MovieModel.Add(movie);
            _dbContext.SaveChanges();
        }

        public void UpdateMovie(MovieModel movie)
        {
            //_dbContext.Entry(movie).State = EntityState.Modified;
            //_dbContext.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movieToDelete = GetMovieById(id);
            if (movieToDelete != null)
            {
                _dbContext.MovieModel.Remove(movieToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
