using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace askisi_mvc_cinema.Repositories
{
    using askisi_mvc_cinema.Models;

    public class ReservationRepository
    {
        private readonly YourDbContext _dbContext;
       

        public ReservationRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ReservationModel GetReservationById(int provoliId, string userUsername)
        {
            return _dbContext.ReservationModel
                .FirstOrDefault(r => r.PROVOLES_ID == provoliId && r.USER_USERNAME == userUsername);
        }

        public void AddReservation(ReservationModel reservation)
        {
            _dbContext.ReservationModel.Add(reservation);
            _dbContext.SaveChanges();
        }

        public void UpdateReservation(ReservationModel reservation)
        {
            //_dbContext.Entry(reservation).State = EntityState.Modified;
            //_dbContext.SaveChanges();
        }

        public void DeleteReservation(int provoliId, string userUsername)
        {
            var reservationToDelete = GetReservationById(provoliId, userUsername);
            if (reservationToDelete != null)
            {
                _dbContext.ReservationModel.Remove(reservationToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
