using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class DrzaveInsertRequest
    {
        
        
            [Required(ErrorMessage = "Potrebno je unijeti naziv drzave!")]

            public string NazivDrzave { get; set; }
        
    }
}
