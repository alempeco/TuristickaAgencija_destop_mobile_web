using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class GradoviInsertRequest
    {
        [Required(ErrorMessage = "Potrebno je unijeti naziv grada!")]

        public string NazivGrada { get; set; }
        public int DrzaveId { get; set; }

    }
}
