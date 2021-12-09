using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class NovostiInsertRequest
    {
        public string Naslov { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string Sadrzaj { get; set; }
        public int? PutovanjeId { get; set; }
        public int? ZaposlenikId { get; set; }

        public byte[] Slika { get; set; }

    }
}
