using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class TipPrevoza
    {
        public int TipPrevozaId { get; set; }
        [Required]
        public string NazivTipa { get; set; }
    }
}
