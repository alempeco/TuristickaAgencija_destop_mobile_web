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
    public class OcjenePutovanjaController : BaseCRUDController<TuristickaAgencija.Model.OcjenePutovanja, OcjenePutovanjaSearchRequest, OcjenePutovanjaInsertRequest, OcjenePutovanjaInsertRequest>
    {
        public OcjenePutovanjaController(ICRUDService<TuristickaAgencija.Model.OcjenePutovanja, OcjenePutovanjaSearchRequest, OcjenePutovanjaInsertRequest, OcjenePutovanjaInsertRequest> service) : base(service)
        {
        }
    }
}
