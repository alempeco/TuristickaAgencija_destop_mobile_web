using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class Uplate
    {
        public int UplataId { get; set; }
        public float Iznos { get; set; }
        public DateTime DatumUplate { get; set; }
        public int RezervacijaId { get; set; }
        public string PutovanjePodaci { get; set; }

        public string TerminPutovanjaPodaci { get; set; }
        public string PutnikKorisnikPodaci { get; set; }

        public string RezervacijaPodaci { get { return PutovanjePodaci + " - " + TerminPutovanjaPodaci + "  " + PutnikKorisnikPodaci; } }



    }
}
