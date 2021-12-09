using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class TerminiSearchRequest
    {
        public int? PutovanjeId { get; set; }
        public int? Godina { get; set; }
        public bool? Aktivno { get; set; }
    }
}
