using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class UplateSearchRequest
    {
        public int? PutnikKorisnikId { get; set; }
        public int? RezervacijaId { get; set; }
    }
}
