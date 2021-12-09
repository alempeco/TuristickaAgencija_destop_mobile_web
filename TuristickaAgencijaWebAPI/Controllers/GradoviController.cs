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
    public class GradoviController : BaseCRUDController<TuristickaAgencija.Model.Gradovi, GradoviSearchRequest, GradoviInsertRequest, GradoviInsertRequest>
    {
        public GradoviController(ICRUDService<TuristickaAgencija.Model.Gradovi, GradoviSearchRequest, GradoviInsertRequest, GradoviInsertRequest> service) : base(service)
        {

        }


    }
}
