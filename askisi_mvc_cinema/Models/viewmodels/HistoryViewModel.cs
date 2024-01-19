using askisi_mvc_cinema.Models.notentity;
using System;
using System.Collections.Generic;

namespace askisi_mvc_cinema.Models.viewmodels
{
    public class HistoryViewModel
    {
        public List<ProvoliModel> PROVOLI_LIST { get; set; }
        public List<ReservationModel> RESERVE_SEATS_LIST { get; set; }
        public string USER_USERNAME { get; set; }

    }
}