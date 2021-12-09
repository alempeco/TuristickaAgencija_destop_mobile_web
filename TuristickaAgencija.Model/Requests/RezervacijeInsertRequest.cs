using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class RezervacijeInsertRequest
    {
        public int PutnikKorisnikId { get; set; }
        public DateTime Vrijeme { get; set; }
        public int TerminPutovanjaId { get; set; }
    }
}
