using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class OnlinePayServices : BaseCRUDService<TuristickaAgencija.Model.OnlinePay, OnlinePaySearchRequest, OnlinePay, OnlinePayInsertRequest, OnlinePayInsertRequest>
    {
        public OnlinePayServices(MyContext db, IMapper mapper) : base(db, mapper)
        {

        }
        public override List<TuristickaAgencija.Model.OnlinePay> Get(OnlinePaySearchRequest search)
        {
            var query = _db.OnlinePay.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme.ToLower().Contains(search.KorisnickoIme.ToLower()));
            }

            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.OnlinePay>>(list);
        }
    }
}
