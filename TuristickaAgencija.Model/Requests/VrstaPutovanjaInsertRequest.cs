using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class VrstaPutovanjaInsertRequest
    {
        public string Oznaka { get; set; }
        public int? Vrijednost { get; set; }
    }
}
