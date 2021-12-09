using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class OnlinePay
    {
        public int OnlinePayId { get; set; }
        public string KorisnickoIme { get; set; }
        public float Iznos { get; set; }
        public int PutniciKorisniciId { get; set; }
        public DateTime DatumUplate { get; set; }
        public string Svrha { get; set; }
    }
}
