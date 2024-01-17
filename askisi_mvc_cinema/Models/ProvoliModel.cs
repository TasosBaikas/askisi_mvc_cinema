using System;
using System.ComponentModel.DataAnnotations;  // Import for annotations
using System.ComponentModel.DataAnnotations.Schema;

namespace askisi_mvc_cinema.Models
{
    public class ProvoliModel
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Movie")]
        public int MOVIES_ID { get; set; }
        public virtual MovieModel Movie { get; set; } // Ensure this is correctly defined

        [ForeignKey("Cinema")]
        public int CINEMAS_ID { get; set; }
        public virtual CinemaModel Cinema { get; set; } // Similar setup for Cinema
        public int NUMBER_OF_SEATS { get; set; }
        public int NUMBER_OF_FREE_SEATS { get; set; }
        public DateTime DATE_FROM { get; set; }
        public DateTime DATE_TO { get; set; }
        public string USER_USERNAME { get; set; }
    }
}