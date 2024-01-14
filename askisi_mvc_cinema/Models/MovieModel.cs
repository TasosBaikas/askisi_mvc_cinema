using System;
using System.ComponentModel.DataAnnotations;

namespace askisi_mvc_cinema.Models
{
    public class MovieModel
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public string CONTENT { get; set; }
        public int LENGTH { get; set; }
        public string TYPE { get; set; }
        public string SUMMARY { get; set; }
        public string DIRECTOR { get; set; }
        public string USER_USERNAME { get; set; }
    }
}