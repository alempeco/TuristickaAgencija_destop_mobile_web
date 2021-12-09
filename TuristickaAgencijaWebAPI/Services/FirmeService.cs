using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class FirmeService : BaseCRUDService<TuristickaAgencija.Model.Firme, FirmeSearchRequest, Database.Firme, FirmeInsertRequest, FirmeInsertRequest>
    {
        public FirmeService(MyContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<TuristickaAgencija.Model.Firme> Get(FirmeSearchRequest search)
        {
            var query = _db.Firme.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.NazivFirme))
            {
                query = query.Where(x => x.NazivFirme.ToLower().Contains(search.NazivFirme.ToLower()));
            }

            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.Firme>>(list);
        }
    }
}
