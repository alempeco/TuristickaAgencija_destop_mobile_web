using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class UplateService : BaseCRUDService<TuristickaAgencija.Model.Uplate, UplateSearchRequest, Database.Uplate, UplateInsertRequest, UplateInsertRequest>
    {
        public UplateService(MyContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<TuristickaAgencija.Model.Uplate> Get(UplateSearchRequest search)
        {
            var query = _db.Set<Database.Uplate>().AsQueryable();

            if (search?.RezervacijaId.HasValue == true)
            {
                query = query.Where(x => x.RezervacijaId == search.RezervacijaId);
            }
            query = query.OrderBy(x => x.UplataId);
            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.Uplate>>(list);
        }
    }
}
