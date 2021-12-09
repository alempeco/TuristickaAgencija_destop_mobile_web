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
    [Route("api/[controller]")]
    [ApiController]
    public class OcjeneController : BaseCRUDController<TuristickaAgencija.Model.Ocjene, object, OcjeneInsertRequest, OcjeneInsertRequest>
    {
        public OcjeneController(ICRUDService<TuristickaAgencija.Model.Ocjene, object, OcjeneInsertRequest, OcjeneInsertRequest> service) : base(service)
        {
        }
    }
}
