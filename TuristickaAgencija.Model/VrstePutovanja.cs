using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class VrstaPutovanja
    {
        public int VrstaPutovanjaId { get; set; }
        public string Oznaka { get; set; }
        public int? Vrijednost { get; set; }
    }
}
