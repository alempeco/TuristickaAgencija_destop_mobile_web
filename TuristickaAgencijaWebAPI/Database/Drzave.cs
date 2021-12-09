using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class Drzave
    {
        public Drzave()
        {
            Gradovi = new HashSet<Gradovi>();
        }

        public int DrzaveId { get; set; }
        public string NazivDrzave { get; set; }

        public ICollection<Gradovi> Gradovi { get; set; }
    }
}
