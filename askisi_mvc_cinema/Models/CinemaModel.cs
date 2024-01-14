using System;
using System.ComponentModel.DataAnnotations;

namespace askisi_mvc_cinema.Models
{
    public class CinemaModel
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public int SEATS { get; set; }
        public string _3D { get; set; }
    }
}