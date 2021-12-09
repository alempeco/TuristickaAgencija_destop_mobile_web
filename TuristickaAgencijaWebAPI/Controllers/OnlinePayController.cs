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
    public class OnlinePayController : BaseCRUDController<TuristickaAgencija.Model.OnlinePay, OnlinePaySearchRequest, OnlinePayInsertRequest, OnlinePayInsertRequest>
    {
        public OnlinePayController(ICRUDService<TuristickaAgencija.Model.OnlinePay, OnlinePaySearchRequest, OnlinePayInsertRequest, OnlinePayInsertRequest> service) : base(service)
        {
        }
    }
}