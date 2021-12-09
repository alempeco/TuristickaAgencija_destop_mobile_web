using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class OnlinePayInsertRequest
    {
        public float Iznos { get; set; }
        public DateTime DatumUplate { get; set; }
       
        public int PutnikKorisnikId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Svrha { get; set; }
    }
}
