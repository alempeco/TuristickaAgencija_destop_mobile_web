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
    public class NovostiController : BaseCRUDController<TuristickaAgencija.Model.Novosti, NovostiSearchRequest, NovostiInsertRequest, NovostiInsertRequest>
    {
        public NovostiController(ICRUDService<TuristickaAgencija.Model.Novosti, NovostiSearchRequest, NovostiInsertRequest, NovostiInsertRequest> service) : base(service)
        {
        }
    }
}
