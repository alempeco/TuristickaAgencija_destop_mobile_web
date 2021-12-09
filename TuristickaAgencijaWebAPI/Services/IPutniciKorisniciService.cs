using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;

namespace TuristickaAgencijaWebAPI.Services
{
    public interface IPutniciKorisniciService
    {
        List<TuristickaAgencija.Model.PutniciKorisnici> Get(PutniciKorisniciSearchRequest request);


        TuristickaAgencija.Model.PutniciKorisnici GetById(int id);


        TuristickaAgencija.Model.PutniciKorisnici Insert(PutniciKorisniciInsertRequest request);


        TuristickaAgencija.Model.PutniciKorisnici Update(int id, PutniciKorisniciInsertRequest request);


        TuristickaAgencija.Model.PutniciKorisnici AutentificirajPutnika(string username, string pass);
    }
}
