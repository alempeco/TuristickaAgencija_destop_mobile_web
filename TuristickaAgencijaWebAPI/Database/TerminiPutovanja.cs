using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class TerminiPutovanja
    {
        public TerminiPutovanja()
        {
            Rezervacije = new HashSet<Rezervacije>();
        }

        public int TerminPutovanjaId { get; set; }
        public bool? Aktivno { get; set; }
        public int? BrojMjesta { get; set; }
        public double? Cijena { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumPovratka { get; set; }
        public int PutovanjeId { get; set; }
        public byte[] Slika { get; set; }
        public int? SmjestajId { get; set; }
        public int? VodicId { get; set; }

        public Putovanja Putovanje { get; set; }
        public Smjestaj Smjestaj { get; set; }
        public TerminiPutovanja TerminPutovanja { get; set; }
        public Vodici Vodic { get; set; }
        public TerminiPutovanja InverseTerminPutovanja { get; set; }
        public ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
