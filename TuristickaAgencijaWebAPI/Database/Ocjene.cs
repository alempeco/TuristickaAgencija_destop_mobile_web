using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class Ocjene
    {
        public Ocjene()
        {
            OcjenePutovanja = new HashSet<OcjenePutovanja>();
        }

        public int OcjenaId { get; set; }
        public string Vrijednost { get; set; }
        public int VrijednostBrojcano { get; set; }

        public ICollection<OcjenePutovanja> OcjenePutovanja { get; set; }
    }
}
