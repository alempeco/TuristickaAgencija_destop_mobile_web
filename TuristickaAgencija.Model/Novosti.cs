using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class Novosti
    {
        public int NovostId { get; set; }
        public string Naslov { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string Sadrzaj { get; set; }
        public int? PutovanjeId { get; set; }
        public string Putovanje { get; set; }
        public int? ZaposlenikId { get; set; }


        public string Zaposlenik { get; set; }
        public byte[] Slika { get; set; }

    }
}
