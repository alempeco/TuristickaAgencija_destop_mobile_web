using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class FirmeInsertRequest
    {
        [Required(ErrorMessage = "Potrebno je unijeti naziv firme!")]

        public string NazivFirme { get; set; }
    }
}
