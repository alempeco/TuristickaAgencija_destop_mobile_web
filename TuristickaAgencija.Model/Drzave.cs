using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TuristickaAgencija.Model
{
    public class Drzave
    {
        public int DrzaveId { get; set; }
        [Required]
        public string NazivDrzave { get; set; }
    }
}
