using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class TerminiPutovanjaInsertRequest
    {
        public int PutovanjeId { get; set; }
        public DateTime? DatumPolaska { get; set; }
        public DateTime? DatumPovratka { get; set; }
        public int? BrojMjesta { get; set; }
        public bool? Aktivno { get; set; }
        public int? SmjestajId { get; set; }
        public int? VodicId { get; set; }

        public double? Cijena { get; set; }
        public byte[] Slika { get; set; }

    }
}
