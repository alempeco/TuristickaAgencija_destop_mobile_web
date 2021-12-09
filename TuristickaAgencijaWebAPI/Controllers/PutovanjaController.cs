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
    public class PutovanjaController : BaseCRUDController<TuristickaAgencija.Model.Putovanja, PutovanjaSearchRequest, PutovanjaInsertRequest, PutovanjaInsertRequest>
    {
        public PutovanjaController(ICRUDService<TuristickaAgencija.Model.Putovanja, PutovanjaSearchRequest, PutovanjaInsertRequest, PutovanjaInsertRequest> service) : base(service)
        {
        }
    }
}
