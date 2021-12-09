using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class OcjenePutovanja
    {
        public int OcjenaPutovanjeId { get; set; }
        public int? PutovanjeId { get; set; }
        public string Putovanje { get; set; }
        public int? OcjenaId { get; set; }
        public string OcjenaVrijednost { get; set; }
        public int? PutnikKorisnikId { get; set; }
        public string PutnikKorisnik { get; set; }
    }
}
