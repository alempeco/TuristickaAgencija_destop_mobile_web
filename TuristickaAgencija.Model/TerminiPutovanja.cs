using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class TerminiPutovanja
    {
        public int TerminPutovanjaId { get; set; }
        public int PutovanjeId { get; set; }
        public string Putovanje { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumPovratka { get; set; }
        public int? BrojMjesta { get; set; }
        public bool? Aktivno { get; set; }
        public int? SmjestajId { get; set; }
        public string Smjestaj { get; set; }
        public int? VodicId { get; set; }

       
        public string Vodic { get; set; }
        public double? Cijena { get; set; }
        public byte[] Slika { get; set; }
        public string TerminPutovanjaPodaci { get; set; }

    }
}
