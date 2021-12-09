using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class RezervacijeSearchRequest
    {
        public int? PutovanjaId { get; set; }
        public int? TerminId { get; set; }
        public int? PutnikKorisnikId { get; set; }
    }
}
