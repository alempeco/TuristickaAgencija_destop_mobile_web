using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class OnlinePaySearchRequest
    {
        public int? PutnikKorisnikId { get; set; }
        public string KorisnickoIme { get; set; }
    }
}
