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
    public class VodiciController : BaseCRUDController<TuristickaAgencija.Model.Vodici, VodicSearchRequest, VodicInsertRequest, VodicInsertRequest>
    {
        public VodiciController(ICRUDService<TuristickaAgencija.Model.Vodici, VodicSearchRequest, VodicInsertRequest, VodicInsertRequest> service) : base(service)
        {
        }
    }
}
