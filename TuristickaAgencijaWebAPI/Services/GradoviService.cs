using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class GradoviService : BaseCRUDService<TuristickaAgencija.Model.Gradovi, GradoviSearchRequest, Database.Gradovi, GradoviInsertRequest, GradoviInsertRequest>
    {
        public GradoviService(MyContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<TuristickaAgencija.Model.Gradovi> Get(GradoviSearchRequest search)
        {
            var query = _db.Gradovi.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.NazivGrada))
            {
                query = query.Where(x => x.NazivGrada.ToLower().Contains(search.NazivGrada.ToLower()));
            }

            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.Gradovi>>(list);
        }
    }
}
