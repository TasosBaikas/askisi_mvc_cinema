using System;
using System.ComponentModel.DataAnnotations;  // Import for annotations

namespace askisi_mvc_cinema.Models
{
    public class ProvoliModel
    {
        [Key]
        public int ID { get; set; }
        public int MOVIES_ID { get; set; }
        public string MOVIES_NAME { get; set; }
        public int CINEMAS_ID { get; set; }
        public string USER_USERNAME { get; set; }
    }
}