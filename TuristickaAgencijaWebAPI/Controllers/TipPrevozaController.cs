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
   
    public class TipPrevozaController : BaseCRUDController<TuristickaAgencija.Model.TipPrevoza, TipPrevozaSearchRequest, TipPrevozaInsertRequest, TipPrevozaInsertRequest>
    {
        public TipPrevozaController(ICRUDService<TuristickaAgencija.Model.TipPrevoza, TipPrevozaSearchRequest, TipPrevozaInsertRequest, TipPrevozaInsertRequest> service) : base(service)
        {

        }


    }
}
