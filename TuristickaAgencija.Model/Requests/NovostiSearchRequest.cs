using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class NovostiSearchRequest
    {
        public int? PutovanjeId { get; set; }
        public DateTime? Vrijeme { get; set; }
        public int? ZaposlenikId { get; set; }
    }
}
