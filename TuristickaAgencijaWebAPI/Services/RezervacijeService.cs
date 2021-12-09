using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class RezervacijeService : BaseCRUDService<TuristickaAgencija.Model.Rezervacije, RezervacijeSearchRequest, Database.Rezervacije, RezervacijeInsertRequest, RezervacijeInsertRequest>
    {
        public RezervacijeService(MyContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<TuristickaAgencija.Model.Rezervacije> Get(RezervacijeSearchRequest search)
        {
            var query = _db.Set<Database.Rezervacije>().AsQueryable();
            if (search?.TerminId.HasValue == true)
            {
                query = query.Where(x => x.TerminPutovanjaId == search.TerminId);

            }
            if (search?.PutnikKorisnikId.HasValue == true)
            {
                query = query.Where(x => x.PutnikKorisnikId == search.PutnikKorisnikId);

            }
            query = query.OrderByDescending(x => x.Vrijeme);
            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.Rezervacije>>(list);


        }
    }
}
