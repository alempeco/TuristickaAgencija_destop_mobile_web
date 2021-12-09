using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class Pretplate
    {
        public int PretplataId { get; set; }
        public bool? Aktivno { get; set; }
        public int? PutnikKorisnikId { get; set; }
        public int? VrstaPutovanjaId { get; set; }

        public PutniciKorisnici PutnikKorisnik { get; set; }
        public VrstePutovanja VrstaPutovanja { get; set; }
    }
}
