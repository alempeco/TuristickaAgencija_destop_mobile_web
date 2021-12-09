using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class Zaposlenici
    {
        public Zaposlenici()
        {
            Novosti = new HashSet<Novosti>();
            Putovanja = new HashSet<Putovanja>();
        }

        public int ZaposlenikId { get; set; }
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Kontakt { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public string Prezime { get; set; }

        public ICollection<Novosti> Novosti { get; set; }
        public ICollection<Putovanja> Putovanja { get; set; }
    }
}
