using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class Rezervacije
    {
        public int RezervacijaId { get; set; }
        public int PutnikKorisnikId { get; set; }
        public string PutnikKorisnikPodaci { get; set; }
        public DateTime Vrijeme { get; set; }
        public int TerminPutovanjaId { get; set; }
        public string TerminPutovanjaPodaci { get; set; }
        public string PutovanjePodaci { get; set; }

        public string RezervacijaPodaci { get { return "Putovanje:" + PutovanjePodaci + "-" + TerminPutovanjaPodaci + "| Putnik: " + PutnikKorisnikPodaci; } }
    }
}
