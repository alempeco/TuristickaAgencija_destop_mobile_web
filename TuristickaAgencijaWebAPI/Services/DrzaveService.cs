using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class DrzaveService : BaseCRUDService<TuristickaAgencija.Model.Drzave, DrzaveSearchRequest, Database.Drzave, DrzaveInsertRequest, DrzaveInsertRequest>
    {
        public DrzaveService(MyContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<TuristickaAgencija.Model.Drzave> Get(DrzaveSearchRequest search)
        {
            var query = _db.Drzave.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.NazivDrzave))
            {
                query = query.Where(x => x.NazivDrzave.ToLower().Contains(search.NazivDrzave.ToLower()));
            }

            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.Drzave>>(list);
        }
    }
}