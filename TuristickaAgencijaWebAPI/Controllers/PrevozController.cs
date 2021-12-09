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
    public class PrevozController : BaseCRUDController<TuristickaAgencija.Model.Prevoz, PrevozSearchRequest, PrevozInsertRequest, PrevozInsertRequest>
    {
        public PrevozController(ICRUDService<TuristickaAgencija.Model.Prevoz, PrevozSearchRequest, PrevozInsertRequest, PrevozInsertRequest> service) : base(service)
        {
        }
    }
}
