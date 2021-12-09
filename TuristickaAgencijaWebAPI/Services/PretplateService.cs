using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class PretplateService : BaseCRUDService<TuristickaAgencija.Model.Pretplate, PretplateSearchRequest, Database.Pretplate, PretplateInsertRequest, PretplateInsertRequest>
    {
        public PretplateService(MyContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<TuristickaAgencija.Model.Pretplate> Get(PretplateSearchRequest search)
        {

            var query = _db.Set<Database.Pretplate>().AsQueryable();
            if (search?.PutnikKorisnikId.HasValue == true)
            {
                query = query.Where(x => x.PutnikKorisnikId == search.PutnikKorisnikId);

            }
            if (search?.VrstaPutovanjaId.HasValue == true)
            {
                query = query.Where(x => x.VrstaPutovanjaId == search.VrstaPutovanjaId);

            }
            query = query.OrderBy(x => x.PretplataId);
            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.Pretplate>>(list);

        }
    }
}
