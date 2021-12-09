using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class PrevozInsertRequest
    {
        public string Naziv { get; set; }
        public float CijenaPoMjestu { get; set; }
        public int BrojMjesta { get; set; }
        public string TipPrevoza { get; set; }
        public int FirmaId { get; set; }
        public int TipPrevozaId { get; set; }

    }
}
