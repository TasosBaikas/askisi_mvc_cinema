using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace askisi_mvc_cinema.Repositories
{
    using askisi_mvc_cinema.Models;

    using System.Data.Entity;
    using System.Configuration;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class YourDbContext : DbContext
    {

        public YourDbContext() : base("name=YourDbContext")
        {
        }


        // Define your DbSet properties for database entities here.
        public DbSet<UserModel> UserModels { get; set; }

        public DbSet<ReservationModel> ReservationModels { get; set; }

        public DbSet<CinemaModel> CinemaModel { get; set; }

        public DbSet<ProvoliModel> ProvoliModels { get; set; }

        public DbSet<MovieModel> MovieModel { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configuring composite key
            modelBuilder.Entity<ReservationModel>()
                .HasKey(r => new { r.PROVOLES_ID, r.USER_USERNAME });


            modelBuilder.Entity<ProvoliModel>()
                    .HasRequired(p => p.Movie)
                    .WithMany()
                    .HasForeignKey(p => p.MOVIES_ID);

            modelBuilder.Entity<ProvoliModel>()
                        .HasRequired(p => p.Cinema)
                        .WithMany()
                        .HasForeignKey(p => p.CINEMAS_ID);

            base.OnModelCreating(modelBuilder);
        }

    }

}