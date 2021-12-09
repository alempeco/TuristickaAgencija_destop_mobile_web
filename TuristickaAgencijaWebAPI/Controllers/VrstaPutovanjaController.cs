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
    public class VrstaPutovanjaController : BaseCRUDController<TuristickaAgencija.Model.VrstaPutovanja, object, VrstaPutovanjaInsertRequest, VrstaPutovanjaInsertRequest>
    {
        public VrstaPutovanjaController(ICRUDService<TuristickaAgencija.Model.VrstaPutovanja, object, VrstaPutovanjaInsertRequest, VrstaPutovanjaInsertRequest> service) : base(service)
        {
        }
    }
}
