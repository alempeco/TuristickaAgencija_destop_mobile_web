using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class OcjenePutovanjaSearchRequest
    {
        public int? PutnikKorisnikId { get; set; }
        public int? PutovanjeId { get; set; }
    }
}
