using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class KomentariService : BaseCRUDService<TuristickaAgencija.Model.Komentari, KomentariSearchRequest, Database.Komentari, KomentariInsertRequest, KomentariInsertRequest>
    {
        public KomentariService(MyContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<TuristickaAgencija.Model.Komentari> Get(KomentariSearchRequest search)
        {
            var query = _db.Set<Komentari>().AsQueryable();
            if (search?.PutnikKorisikId.HasValue == true)
            {
                query = query.Where(x => x.PutnikKorisnikId == search.PutnikKorisikId);

            }
            if (search?.PutovanjeId.HasValue == true)
            {
                query = query.Where(x => x.PutovanjeId == search.PutovanjeId);

            }
            query = query.OrderByDescending(x => x.Vrijeme);
            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.Komentari>>(list);
        }
    }
}
