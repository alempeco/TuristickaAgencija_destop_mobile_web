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
 
    public class DrzaveController : BaseCRUDController<TuristickaAgencija.Model.Drzave, DrzaveSearchRequest, DrzaveInsertRequest, DrzaveInsertRequest>
    {
        public DrzaveController(ICRUDService<TuristickaAgencija.Model.Drzave, DrzaveSearchRequest, DrzaveInsertRequest, DrzaveInsertRequest> service) : base(service)
        {

        }


    }
}
