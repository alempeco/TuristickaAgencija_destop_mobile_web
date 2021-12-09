using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class Pretplate
    {
        public int PretplataId { get; set; }
        public int? PutnikKorisnikId { get; set; }
        public string PutnikKorisnik { get; set; }
        public int? VrstaPutovanjaId { get; set; }
        public string VrstaPutovanja { get; set; }
        public bool? Aktivno { get; set; }
    }
}
