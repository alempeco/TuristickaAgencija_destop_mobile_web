using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class Komentari
    {
        public int KomentarId { get; set; }

        public DateTime? Vrijeme { get; set; }
        public string Sadrzaj { get; set; }
        public int? PutnikKorisnikId { get; set; }
        public string PutnikKorisnik { get; set; }
        public int? PutovanjeId { get; set; }
        public string Putovanje { get; set; }

    }
}
