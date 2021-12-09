using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class OcjenePutovanjaService : BaseCRUDService<TuristickaAgencija.Model.OcjenePutovanja, OcjenePutovanjaSearchRequest, Database.OcjenePutovanja, OcjenePutovanjaInsertRequest, OcjenePutovanjaInsertRequest>
    {
        public OcjenePutovanjaService(MyContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<TuristickaAgencija.Model.OcjenePutovanja> Get(OcjenePutovanjaSearchRequest search)
        {
            var query = _db.Set<OcjenePutovanja>().AsQueryable();
            if (search?.PutnikKorisnikId.HasValue == true)
            {
                query = query.Where(x => x.PutnikKorisnikId == search.PutnikKorisnikId);
            }
            if (search?.PutovanjeId.HasValue == true)
            {
                query = query.Where(x => x.PutovanjeId == search.PutovanjeId);
            }
            query = query.OrderBy(x => x.PutnikKorisnikId);
            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.OcjenePutovanja>>(list);
        }
    }
}
