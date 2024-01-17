using askisi_mvc_cinema.Models.notentity;
using System;
using System.Collections.Generic;

namespace askisi_mvc_cinema.Models.viewmodels
{
    public class ProvoliViewModel
    {
        public List<ProvoliModel> PROVOLI_LIST { get; set; }
        public ProvoliRequest PROVOLI_REQUEST { get; set; }
        public ReservationModel RESERVE_SEATS { get; set; }


    }
}