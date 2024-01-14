using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace askisi_mvc_cinema.Repositories
{
    using askisi_mvc_cinema.Models;

    using System.Data.Entity;
    using System.Configuration;

    public class YourDbContext : DbContext
    {
        public YourDbContext() : base("name=YourDbContext")
        {
        }

        // Define your DbSet properties for database entities here.
        public DbSet<UserModel> UserModel { get; set; }

        public DbSet<ReservationModel> ReservationModel { get; set; }

        public DbSet<CinemaModel> CinemaModel { get; set; }

        public DbSet<ProvoliModel> ProvoliModel { get; set; }

        public DbSet<MovieModel> MovieModel { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Configuring composite key
            modelBuilder.Entity<ReservationModel>()
                .HasKey(r => new { r.PROVOLES_ID, r.USER_USERNAME });

            modelBuilder.Entity<ProvoliModel>()
                .HasKey(r => new { r.MOVIES_ID, r.CINEMAS_ID });


            base.OnModelCreating(modelBuilder); // Call it once at the end
        }

    }

}