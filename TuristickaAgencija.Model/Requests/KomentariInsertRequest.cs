using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class KomentariInsertRequest
    {
        public string Naslov { get; set; }
        public DateTime? Vrijeme { get; set; }
        public string Sadrzaj { get; set; }
        public int? PutnikKorisnikId { get; set; }
        public int? PutovanjeId { get; set; }

    }
}
