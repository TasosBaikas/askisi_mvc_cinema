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

        public UserRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserModel GetUserByUsername(string username)
        {

            return _dbContext.UserModel.Find(username);
        }


        public void AddUser(UserModel user)
        {
            _dbContext.UserModel.Add(user);
            _dbContext.SaveChanges();
        }

    }

}