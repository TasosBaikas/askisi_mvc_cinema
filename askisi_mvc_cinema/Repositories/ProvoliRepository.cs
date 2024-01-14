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

        public ProvoliRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProvoliModel> GetAllProvoli()
        {
            return _dbContext.ProvoliModel.ToList();
        }

        public ProvoliModel GetProvoliById(int id)
        {
            return _dbContext.ProvoliModel.FirstOrDefault(p => p.ID == id);
        }

        public void AddProvoli(ProvoliModel provoli)
        {
            _dbContext.ProvoliModel.Add(provoli);
            _dbContext.SaveChanges();
        }

        public void UpdateProvoli(ProvoliModel provoli)
        {
            //_dbContext.Entry(provoli).State = EntityState.Modified;
            //_dbContext.SaveChanges();
        }

        public void DeleteProvoli(int id)
        {
            var provoliToDelete = GetProvoliById(id);
            if (provoliToDelete != null)
            {
                _dbContext.ProvoliModel.Remove(provoliToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
