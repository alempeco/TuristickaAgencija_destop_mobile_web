using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class PrevozSearchRequest
    {
        public int? FirmaId { get; set; }
        public string Naziv { get; set; }
    }
}
