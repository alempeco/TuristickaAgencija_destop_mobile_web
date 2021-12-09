using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class VodiciService : BaseCRUDService<TuristickaAgencija.Model.Vodici, VodicSearchRequest, Database.Vodici, VodicInsertRequest, VodicInsertRequest>
    {
        public VodiciService(MyContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<TuristickaAgencija.Model.Vodici> Get(VodicSearchRequest search)
        {
            var query = _db.Set<Database.Vodici>().AsQueryable();
            if (search?.Zauzet.HasValue == true)
            {
                query = query.Where(x => x.Zauzet == search.Zauzet);

            }
            query = query.OrderBy(x => x.Ime);
            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.Vodici>>(list);

        }


    }
}
