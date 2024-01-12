using System;

namespace askisi_mvc_cinema.Models
{
    public class ReservationModel
    {
        public int PROVOLES_MOVIES_ID { get; set; }
        public string PROVOLES_MOVIES_NAME { get; set; }
        public int PROVOLES_CINEMAS_ID { get; set; }
        public int CUSTOMERS_ID { get; set; }
        public int NUMBER_OF_SEATS { get; set; }
        public string USER_USERNAME { get; set; }
    }
}