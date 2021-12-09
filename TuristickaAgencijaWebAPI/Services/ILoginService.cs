using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuristickaAgencijaWebAPI.Services
{
    public interface ILoginService
    {
        TuristickaAgencija.Model.KorisnikLogin AutentificirajPutnika(string username, string pass);
        TuristickaAgencija.Model.KorisnikLogin Autentificiraj(string username, string pass);
    }
}
