using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencijaWebAPI.Services;

namespace TuristickaAgencijaWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TSearch> : ControllerBase
    {
        private readonly IService<T, TSearch> _service;
        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<T>> Get([FromQuery] TSearch search)
        {

            return _service.Get(search);
        }


        [HttpGet("{id}")]
        public ActionResult<T> GetById(int id)
        {
            return _service.GetById(id);
        }

    }
}
