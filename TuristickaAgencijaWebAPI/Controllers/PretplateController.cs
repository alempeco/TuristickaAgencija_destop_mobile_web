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
    public class PretplateController : BaseCRUDController<TuristickaAgencija.Model.Pretplate, PretplateSearchRequest, PretplateInsertRequest, PretplateInsertRequest>
    {
        public PretplateController(ICRUDService<TuristickaAgencija.Model.Pretplate, PretplateSearchRequest, PretplateInsertRequest, PretplateInsertRequest> service) : base(service)
        {
        }
    }
}
