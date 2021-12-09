using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class TipPrevozaService : BaseCRUDService<TuristickaAgencija.Model.TipPrevoza, TipPrevozaSearchRequest, Database.TipPrevoza, TipPrevozaInsertRequest, TipPrevozaInsertRequest>
    {
        public TipPrevozaService(MyContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<TuristickaAgencija.Model.TipPrevoza> Get(TipPrevozaSearchRequest search)
        {
            var query = _db.TipPrevoza.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.NazivTipa))
            {
                query = query.Where(x => x.NazivTipa.ToLower().Contains(search.NazivTipa.ToLower()));
            }

            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.TipPrevoza>>(list);
        }
    }
}