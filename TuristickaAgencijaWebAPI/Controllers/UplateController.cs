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
    public class UplateController : BaseCRUDController<TuristickaAgencija.Model.Uplate, UplateSearchRequest, UplateInsertRequest, UplateInsertRequest>
    {
        public UplateController(ICRUDService<TuristickaAgencija.Model.Uplate, UplateSearchRequest, UplateInsertRequest, UplateInsertRequest> service) : base(service)
        {
        }
    }
}
