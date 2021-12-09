using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class Novosti
    {
        public int NovostId { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string Naslov { get; set; }
        public int? PutovanjeId { get; set; }
        public string Sadrzaj { get; set; }
        public byte[] Slika { get; set; }
        public int? ZaposlenikId { get; set; }

        public Putovanja Putovanje { get; set; }
        public Zaposlenici Zaposlenik { get; set; }
    }
}
