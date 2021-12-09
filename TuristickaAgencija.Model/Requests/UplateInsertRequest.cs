using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class UplateInsertRequest
    {
        public float Iznos { get; set; }
        public DateTime DatumUplate { get; set; }
        public int RezervacijaId { get; set; }
        public int? PutnikKorisnikId { get; set; }
    }
}
