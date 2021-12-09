using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class Firme
    {
        public int FirmaId { get; set; }
        [Required]
        public string NazivFirme { get; set; }
    }
}
