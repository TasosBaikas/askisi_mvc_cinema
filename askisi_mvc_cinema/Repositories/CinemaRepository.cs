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

        public CinemaRepository()
        {
            _dbContext = new YourDbContext();
        }

        public List<CinemaModel> GetAllCinemas()
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
            if (cinema != null)
            {
                _dbContext.Entry(cinema).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
            }
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

        public List<CinemaModel> GetCinemasByIds(List<int> cinemasIds)
        {
            return _dbContext.CinemaModel.Where(m => cinemasIds.Contains(m.ID)).ToList();
        }
    }
}
