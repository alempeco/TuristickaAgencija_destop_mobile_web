using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Requests
{
    public class ZaposleniciInsertRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Kontakt { get; set; }
        public string Email { get; set; }

        public string KorisnickoIme { get; set; }
        public string Password { get; set; }

        public string PasswordPotvrda { get; set; }
    }
}
