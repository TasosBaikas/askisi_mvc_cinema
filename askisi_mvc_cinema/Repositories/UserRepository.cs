using askisi_mvc_cinema.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace askisi_mvc_cinema.Repositories
{
    public class UserRepository
    {
        private readonly YourDbContext _dbContext;

        public UserRepository()
        {
            _dbContext = new YourDbContext();
        }

        public UserModel GetUserByUsername(string username)
        {

            return _dbContext.UserModels.Find(username);
        }

        public List<UserModel> GetAllUsers()
        {
            return _dbContext.UserModels.ToList();
        }

        public void DeleteUser(UserModel user)
        {
            if (user != null)
            {
                _dbContext.UserModels.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public void AddUser(UserModel user)
        {
            _dbContext.UserModels.Add(user);
            _dbContext.SaveChanges();
        }

    }

}