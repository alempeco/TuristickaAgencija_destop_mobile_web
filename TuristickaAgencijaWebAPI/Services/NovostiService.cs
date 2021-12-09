using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class NovostiService : BaseCRUDService<TuristickaAgencija.Model.Novosti, NovostiSearchRequest, Database.Novosti, NovostiInsertRequest, NovostiInsertRequest>
    {
        public NovostiService(MyContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<TuristickaAgencija.Model.Novosti> Get(NovostiSearchRequest search)
        {
            var query = _db.Set<Database.Novosti>().AsQueryable();

            if (search?.PutovanjeId.HasValue == true)
            {
                query = query.Where(x => x.PutovanjeId == search.PutovanjeId);
            }
            if (search?.ZaposlenikId.HasValue == true)
            {
                query = query.Where(x => x.ZaposlenikId == search.ZaposlenikId);
            }
            if (search?.Vrijeme.HasValue == true)
            {
                query = query.Where(x => x.DatumVrijeme == search.Vrijeme);
            }
            query = query.OrderByDescending(x => x.NovostId);
            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.Novosti>>(list);
        }
    }
}
