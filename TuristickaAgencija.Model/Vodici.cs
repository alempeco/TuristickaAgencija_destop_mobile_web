using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class Vodici
    {
        public int VodicId { get; set; }
        public string Vodic { get { return Ime + " " + Prezime; } }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Kontakt { get; set; }
        public string Jmbg { get; set; }
        public bool? Zauzet { get; set; }
        public byte[] Slika { get; set; }

    }
}
