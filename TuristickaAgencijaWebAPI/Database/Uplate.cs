using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class Uplate
    {
        public int UplataId { get; set; }
        public DateTime DatumUplate { get; set; }
        public float Iznos { get; set; }
        public int RezervacijaId { get; set; }

        public Rezervacije Rezervacija { get; set; }
    }
}
