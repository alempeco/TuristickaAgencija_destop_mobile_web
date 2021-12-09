using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class TipPrevozaInsertRequest
    {
        [Required(ErrorMessage = "Potrebno je unijeti tip prevoza!")]

        public string NazivTipa { get; set; }
    }
}
