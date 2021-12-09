using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class SmjestajSearchRequest
    {
        public int? GradId { get; set; }
        public string Naziv { get; set; }
    }
}
