using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class Prevoz
    {
        public int PrevozId { get; set; }
        public string PrevozPodaci { get { return TipPrevoza + " " + Firma; } }
       //public string Naziv { get; set; }
        public float CijenaPoMjestu { get; set; }
        public int BrojMjesta { get; set; }
        //public string TipPrevoza { get; set; }
        public int FirmaId { get; set; }
        public string Firma { get; set; }
        public int TipPrevozaId { get; set; }
        public string TipPrevoza { get; set; }
    }
}
