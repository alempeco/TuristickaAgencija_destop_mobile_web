using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class Firme
    {
        public Firme()
        {
            Prevoz = new HashSet<Prevoz>();
        }

        public int FirmaId { get; set; }
        public string NazivFirme { get; set; }

        public ICollection<Prevoz> Prevoz { get; set; }
    }
}
