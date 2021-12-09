using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class Smjestaj
    {
        public Smjestaj()
        {
            TerminiPutovanja = new HashSet<TerminiPutovanja>();
        }

        public int SmjestajId { get; set; }
        public double? CijenaNoc { get; set; }
        public int GradId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string TipSobe { get; set; }
        public byte[] Slika { get; set; }

        public Gradovi Grad { get; set; }
        public ICollection<TerminiPutovanja> TerminiPutovanja { get; set; }
    }
}
