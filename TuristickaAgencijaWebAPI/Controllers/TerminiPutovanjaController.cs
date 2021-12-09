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
    public class TerminiPutovanjaController : BaseCRUDController<TuristickaAgencija.Model.TerminiPutovanja, TerminiSearchRequest, TerminiPutovanjaInsertRequest, TerminiPutovanjaInsertRequest>
    {
        public TerminiPutovanjaController(ICRUDService<TuristickaAgencija.Model.TerminiPutovanja, TerminiSearchRequest, TerminiPutovanjaInsertRequest, TerminiPutovanjaInsertRequest> service) : base(service)
        {
        }
    }
}
