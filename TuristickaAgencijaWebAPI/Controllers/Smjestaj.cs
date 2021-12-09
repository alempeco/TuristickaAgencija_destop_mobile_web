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
    public class SmjestajController : BaseCRUDController<TuristickaAgencija.Model.Smjestaj, SmjestajSearchRequest, SmjestajInsertRequest, SmjestajInsertRequest>
    {
        public SmjestajController(ICRUDService<TuristickaAgencija.Model.Smjestaj, SmjestajSearchRequest, SmjestajInsertRequest, SmjestajInsertRequest> service) : base(service)
        {
        }
    }
}
