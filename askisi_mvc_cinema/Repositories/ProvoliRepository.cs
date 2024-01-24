using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace askisi_mvc_cinema.Repositories
{
    using askisi_mvc_cinema.Models;

    public class ProvoliRepository
    {
        private readonly YourDbContext _dbContext;

        public ProvoliRepository()
        {
            _dbContext = new YourDbContext();
        }

        public List<ProvoliModel> GetAllProvoli()
        {
            return _dbContext.ProvoliModels.ToList();
        }

        public List<ProvoliModel> GetAllProvolisThatAreInSpecificTime(DateTime dateFrom, DateTime dateTo)
        {
            return _dbContext.ProvoliModels
                .Where(provoli => provoli.DATE_FROM >= dateFrom && provoli.DATE_FROM <= dateTo)
                .Include(p => p.Movie)
                .Include(p => p.Cinema)
                .ToList();
        }

        public ProvoliModel GetProvoliById(int id)
        {
            return _dbContext.ProvoliModels.FirstOrDefault(p => p.ID == id);
        }

        public void AddProvoli(ProvoliModel provoli)
        {
            _dbContext.ProvoliModels.Add(provoli);
            _dbContext.SaveChanges();
        }

        public void UpdateProvoli(ProvoliModel provoli)
        {
            if (provoli != null)
            {
                _dbContext.Entry(provoli).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }


        public void DeleteProvoli(int id)
        {
            var provoliToDelete = GetProvoliById(id);
            if (provoliToDelete != null)
            {
                _dbContext.ProvoliModels.Remove(provoliToDelete);
                _dbContext.SaveChanges();
            }
        }

        internal List<ProvoliModel> GetProvolisByIds(List<int> provolesIds)
        {
            return _dbContext.ProvoliModels
                .Where(provoli => provolesIds.Contains(provoli.ID))
                .Include(p => p.Movie)
                .Include(p => p.Cinema)
                .ToList();
        }

    }
}
