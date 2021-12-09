using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class PutovanjaInsertRequest
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public int? VrstaPutovanjaId { get; set; }
        public int? ZaposlenikId { get; set; }
        public byte[] Slika { get; set; }

        public int? GradId { get; set; }
        public int? PrevozId{ get; set; }



    }
}
