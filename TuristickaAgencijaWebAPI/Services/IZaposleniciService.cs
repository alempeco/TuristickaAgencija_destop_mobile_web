using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;

namespace TuristickaAgencijaWebAPI.Services
{
    public interface IZaposleniciService
    {
        List<TuristickaAgencija.Model.Zaposlenici> Get(ZaposleniciSearchRequest request);


        TuristickaAgencija.Model.Zaposlenici GetById(int id);


        TuristickaAgencija.Model.Zaposlenici Insert(ZaposleniciInsertRequest request);


        TuristickaAgencija.Model.Zaposlenici Update(int id, ZaposleniciInsertRequest request);


        TuristickaAgencija.Model.Zaposlenici Authenticiraj(string username, string pass);

    }
}
