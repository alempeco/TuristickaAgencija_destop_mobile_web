using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    ////govori da pozivi u ovom kontroleru trebaju biti logirani, naprotiv vraca 401
    ////ako to nema, pozivi su otvoreni za izvrsavanje
    /////takodjer "puca" na dijelu registracije mobilne aplikacije...error 401 ne moze se registrovi, ako predthodno nije prijavljen
    // sto nije logicno!
    [Route("api/[controller]")]
    [ApiController]
    public class PutniciKorisniciController : ControllerBase
    {
        private readonly IPutniciKorisniciService _service;

        public PutniciKorisniciController(IPutniciKorisniciService service)
        {
            _service = service;
        }


        [HttpGet]

        public List<TuristickaAgencija.Model.PutniciKorisnici> Get([FromQuery] PutniciKorisniciSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpPost]
        public TuristickaAgencija.Model.PutniciKorisnici Insert(PutniciKorisniciInsertRequest request)

        {
            return _service.Insert(request);
        }



        [HttpPut("{id}")]
        public TuristickaAgencija.Model.PutniciKorisnici Update(int id, [FromBody] PutniciKorisniciInsertRequest request)

        {
            return _service.Update(id, request);
        }


        [HttpGet("{id}")]
        public TuristickaAgencija.Model.PutniciKorisnici GetById(int id)

        {
            return _service.GetById(id);
        }
    }
}
