using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class Prevoz
    {
        public Prevoz()
        {
            Putovanja = new HashSet<Putovanja>();
        }

        public int PrevozId { get; set; }
        public int BrojMjesta { get; set; }
        public float CijenaPoMjestu { get; set; }
        public int? FirmaId { get; set; }
        public int? TipPrevozaId { get; set; }

        public Firme Firma { get; set; }
        public TipPrevoza TipPrevoza { get; set; }
        public ICollection<Putovanja> Putovanja { get; set; }
    }
}
