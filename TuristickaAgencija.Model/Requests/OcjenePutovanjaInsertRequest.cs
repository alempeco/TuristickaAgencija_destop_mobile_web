using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class OcjenePutovanjaInsertRequest
    {
        public int? PutovanjeId { get; set; }
        public int? OcjenaId { get; set; }
        public int? PutnikKorisnikId { get; set; }
    }
}
