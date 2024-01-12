using System;

namespace askisi_mvc_cinema.Models
{
    public class UserModel
    {
        public string USERNAME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string SALT { get; set; }
        public string ROLE { get; set; }
    }
}