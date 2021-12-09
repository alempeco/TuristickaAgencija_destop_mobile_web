using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class Vodici
    {
        public Vodici()
        {
            TerminiPutovanja = new HashSet<TerminiPutovanja>();
        }

        public int VodicId { get; set; }
        public string Ime { get; set; }
        public string Jmbg { get; set; }
        public string Kontakt { get; set; }
        public string Prezime { get; set; }
        public byte[] Slika { get; set; }
        public bool? Zauzet { get; set; }

        public ICollection<TerminiPutovanja> TerminiPutovanja { get; set; }
    }
}
