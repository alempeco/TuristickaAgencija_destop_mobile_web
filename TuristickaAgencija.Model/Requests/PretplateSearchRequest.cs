using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class PretplateSearchRequest
    {
        public int? PutnikKorisnikId { get; set; }
        public int? VrstaPutovanjaId { get; set; }
    }
}
