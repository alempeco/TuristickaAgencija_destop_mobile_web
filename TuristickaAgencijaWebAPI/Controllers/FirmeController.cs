using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Services;

namespace TuristickaAgencijaWebAPI.Controllers
{
 
    public class FirmeController : BaseCRUDController<TuristickaAgencija.Model.Firme, FirmeSearchRequest, FirmeInsertRequest, FirmeInsertRequest>
    {
        public FirmeController(ICRUDService<TuristickaAgencija.Model.Firme, FirmeSearchRequest, FirmeInsertRequest, FirmeInsertRequest> service) : base(service)
        {

        }


    }
}
