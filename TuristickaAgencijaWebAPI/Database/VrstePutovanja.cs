using System;
using System.Collections.Generic;

namespace TuristickaAgencijaWebAPI.Database
{
    public partial class VrstePutovanja
    {
        public VrstePutovanja()
        {
            Pretplate = new HashSet<Pretplate>();
            Putovanja = new HashSet<Putovanja>();
        }

        public int VrstaPutovanjaId { get; set; }
        public string Oznaka { get; set; }
        public int? Vrijednost { get; set; }

        public ICollection<Pretplate> Pretplate { get; set; }
        public ICollection<Putovanja> Putovanja { get; set; }
    }
}
