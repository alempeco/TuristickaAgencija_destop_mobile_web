using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class Putovanja
    {
        public int PutovanjaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
        public int? VrstaPutovanjaId { get; set; }
        public string VrstaPutovanja { get; set; }
        public int? ZaposlenikId { get; set; }
        public int? GradId { get; set; }
        public string Grad { get; set; }
        public int? PrevozId { get; set; }
        public string Prevoz { get; set; }
        public string Putovanje { get { return Naziv + " | " + Grad + " | " + VrstaPutovanja; } }


    }
}
