using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class KomentariSearchRequest
    {
        public int? PutnikKorisikId { get; set; }
        public int? PutovanjeId { get; set; }
    }
}
