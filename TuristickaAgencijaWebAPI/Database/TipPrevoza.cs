using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class TipPrevoza
    {
        public TipPrevoza()
        {
            Prevoz = new HashSet<Prevoz>();
        }

        public int TipPrevozaId { get; set; }
        public string NazivTipa { get; set; }

        public ICollection<Prevoz> Prevoz { get; set; }
    }
}
