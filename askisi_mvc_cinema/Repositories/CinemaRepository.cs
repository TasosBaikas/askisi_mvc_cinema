using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace askisi_mvc_cinema.Repositories
{
    using askisi_mvc_cinema.Models;

    public class CinemaRepository
    {
        private readonly YourDbContext _dbContext;

        public CinemaRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CinemaModel> GetAllCinemas()
        {
            return _dbContext.CinemaModel.ToList();
        }

        public CinemaModel GetCinemaById(int id)
        {
            return _dbContext.CinemaModel.FirstOrDefault(c => c.ID == id);
        }

        public void AddCinema(CinemaModel cinema)
        {
            _dbContext.CinemaModel.Add(cinema);
            _dbContext.SaveChanges();
        }

        public void UpdateCinema(CinemaModel cinema)
        {
            //_dbContext.Entry(cinema).State = EntityState.Modified;
            //_dbContext.SaveChanges();
        }

        public void DeleteCinema(int id)
        {
            var cinemaToDelete = GetCinemaById(id);
            if (cinemaToDelete != null)
            {
                _dbContext.CinemaModel.Remove(cinemaToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
