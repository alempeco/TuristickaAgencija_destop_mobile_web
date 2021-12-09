using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class PutovanjaService : BaseCRUDService<TuristickaAgencija.Model.Putovanja, PutovanjaSearchRequest, Putovanja, PutovanjaInsertRequest, PutovanjaInsertRequest>, ICRUDService<TuristickaAgencija.Model.Putovanja, PutovanjaSearchRequest, PutovanjaInsertRequest, PutovanjaInsertRequest>
    {

        public PutovanjaService(MyContext db, IMapper mapper) : base(db, mapper)
        {

        }
        public override List<TuristickaAgencija.Model.Putovanja> Get(PutovanjaSearchRequest search)
        {
            var query = _db.Set<Putovanja>().AsQueryable();
            if (search?.VrstaPutovanjaId.HasValue == true)
            {
                query = query.Where(x => x.VrstaPutovanjaId == search.VrstaPutovanjaId);

            }
            query = query.OrderBy(x => x.Naziv);
            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.Putovanja>>(list);
        }

    }
}
