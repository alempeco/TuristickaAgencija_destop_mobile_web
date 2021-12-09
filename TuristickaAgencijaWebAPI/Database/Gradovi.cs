using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class Gradovi
    {
        public Gradovi()
        {
            Putovanja = new HashSet<Putovanja>();
            Smjestaj = new HashSet<Smjestaj>();
        }

        public int GradId { get; set; }
        public string NazivGrada { get; set; }
        public int? DrzaveId { get; set; }

        public Drzave Drzave { get; set; }
        public ICollection<Putovanja> Putovanja { get; set; }
        public ICollection<Smjestaj> Smjestaj { get; set; }
    }
}
