using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class OnlinePay

    {
        public int OnlinePayId { get; set; }
        public string KorisnickoIme { get; set; }
        public float Iznos { get; set; }
        public int PutniciKorisniciId { get; set; }
        public DateTime DatumUplate { get; set; }
        public string Svrha { get; set; }
    }
}
