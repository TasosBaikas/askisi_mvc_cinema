using System;
using System.ComponentModel.DataAnnotations;  // Import for annotations

namespace askisi_mvc_cinema.Models
{
    public class UserModel
    {
        [Key]  // Annotates USERNAME as the primary key
        public string USERNAME { get; set; }

        public string EMAIL { get; set; }

        public string PASSWORD { get; set; }

        public DateTime CREATE_TIME { get; set; }

        public string SALT { get; set; }

        public string ROLE { get; set; }
    }
}
