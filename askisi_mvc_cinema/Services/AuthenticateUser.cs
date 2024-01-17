using askisi_mvc_cinema.Models;
using askisi_mvc_cinema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace askisi_mvc_cinema.Services
{
    public class AuthenticateUser
    {


        public UserModel AuthenticateAndReturnUser(string username, string password)
        {

            UserRepository userRepository = new UserRepository();

            UserModel userModel = userRepository.GetUserByUsername(username);
            if (userModel == null)
                throw new UnauthorizedAccessException("Authentication failed. User does not exist.");

            if (userModel.SALT == null)
                throw new UnauthorizedAccessException("Authentication failed. User has not the proper security.");


            if (userModel.PASSWORD == null)
                throw new UnauthorizedAccessException("Authentication failed. User has no password.");

            if (password == null)
                throw new UnauthorizedAccessException("Authentication failed. wrong password.");


            string hashedPassword = HashPassword(password, userModel.SALT);

            if (hashedPassword != userModel.PASSWORD)
                throw new UnauthorizedAccessException("Authentication failed. wrong password.");


            return userModel;
        }


        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Concatenate the salt and password
                string saltedPassword = salt + password;

                // Compute the hash
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                // Convert the byte array to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

    }
}