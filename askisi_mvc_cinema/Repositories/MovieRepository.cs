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

        public MovieRepository()
        {
            _dbContext = new YourDbContext();
        }

        public List<MovieModel> GetAllMovies()
        {
            return _dbContext.MovieModel.ToList();
        }

        public List<MovieModel> GetMoviesByIds(List<int> ids)
        {
            return _dbContext.MovieModel.Where(m => ids.Contains(m.ID)).ToList();
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
            if (movie != null)
            {
                _dbContext.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
            }
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
