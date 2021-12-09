using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class OcjenePutovanja
    {
        public int OcjenaPutovanjeId { get; set; }
        public int? OcjenaId { get; set; }
        public int? PutnikKorisnikId { get; set; }
        public int? PutovanjeId { get; set; }

        public Ocjene Ocjena { get; set; }
        public PutniciKorisnici PutnikKorisnik { get; set; }
        public Putovanja Putovanje { get; set; }
    }
}
