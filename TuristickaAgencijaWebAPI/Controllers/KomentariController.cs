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
    public class KomentariController : BaseCRUDController<TuristickaAgencija.Model.Komentari, KomentariSearchRequest, KomentariInsertRequest, KomentariInsertRequest>
    {
        public KomentariController(ICRUDService<TuristickaAgencija.Model.Komentari, KomentariSearchRequest, KomentariInsertRequest, KomentariInsertRequest> service) : base(service)
        {
        }
    }
}
