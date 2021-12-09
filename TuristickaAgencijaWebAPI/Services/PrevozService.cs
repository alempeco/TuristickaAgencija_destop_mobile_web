using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class PrevozService : BaseCRUDService<TuristickaAgencija.Model.Prevoz, PrevozSearchRequest, Prevoz, PrevozInsertRequest, PrevozInsertRequest>
    {
        public PrevozService(MyContext db, IMapper mapper) : base(db, mapper)
        {

        }
        public override List<TuristickaAgencija.Model.Prevoz> Get(PrevozSearchRequest search)
        {
            var query = _db.Set<Prevoz>().AsQueryable();
            if (search?.FirmaId.HasValue == true)
            {
                query = query.Where(x => x.FirmaId == search.FirmaId);

            }
            query = query.OrderBy(x => x.CijenaPoMjestu);
            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.Prevoz>>(list);
        }
    }
}
