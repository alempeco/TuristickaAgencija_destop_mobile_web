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
    public class RezervacijeController : BaseCRUDController<TuristickaAgencija.Model.Rezervacije, RezervacijeSearchRequest, RezervacijeInsertRequest, RezervacijeInsertRequest>
    {
        public RezervacijeController(ICRUDService<TuristickaAgencija.Model.Rezervacije, RezervacijeSearchRequest, RezervacijeInsertRequest, RezervacijeInsertRequest> service) : base(service)
        {
        }
    }
}
