using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class ZaposleniciService : IZaposleniciService
    {
        private readonly MyContext _db;

        private readonly IMapper _mapper;

        public ZaposleniciService(MyContext context, IMapper mapper)

        {
            _db = context;
            _mapper = mapper;
        }


        public static string GenerateHash(string salt, string password)

        {
            byte[] src = Convert.FromBase64String(salt);

            byte[] bytes = Encoding.Unicode.GetBytes(password);

            byte[] dst = new byte[src.Length + bytes.Length];


            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);

            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);


            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");

            byte[] inArray = algorithm.ComputeHash(dst);

            return Convert.ToBase64String(inArray);
        }



        public TuristickaAgencija.Model.Zaposlenici Authenticiraj(string username, string pass)
        {
            var user = _db.Zaposlenici.Where(x => x.KorisnickoIme == username).FirstOrDefault();


            if (user != null)

            {
                var newHash = GenerateHash(user.LozinkaSalt, pass);



                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<TuristickaAgencija.Model.Zaposlenici>(user);

                }
            }
            return null;
        }

        public static string GenerateSalt()

        {

            var buf = new byte[16];

            (new RNGCryptoServiceProvider()).GetBytes(buf);

            return Convert.ToBase64String(buf);


        }

        public List<TuristickaAgencija.Model.Zaposlenici> Get(ZaposleniciSearchRequest request)
        {
            {
                var query = _db.Set<Database.Zaposlenici>().AsQueryable();
                if (!string.IsNullOrWhiteSpace(request?.KorisnickoIme))
                {
                    query = query.Where(x => x.KorisnickoIme == request.KorisnickoIme);

                }
                query = query.OrderBy(x => x.KorisnickoIme);
                return _mapper.Map<List<TuristickaAgencija.Model.Zaposlenici>>(query);

            }
        }

        public TuristickaAgencija.Model.Zaposlenici GetById(int id)
        {
            var entity = _db.Zaposlenici.Find(id);


            return _mapper.Map<TuristickaAgencija.Model.Zaposlenici>(entity);

        }

        public TuristickaAgencija.Model.Zaposlenici Insert(ZaposleniciInsertRequest request)
        {
            var entity = _mapper.Map<Database.Zaposlenici>(request);


            if (request.Password != request.PasswordPotvrda)

            {
                throw new Exception("Passwordi se ne slažu");

            }

            entity.LozinkaSalt = GenerateSalt();

            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);


            _db.Zaposlenici.Add(entity);

            _db.SaveChanges();

            _db.SaveChanges();


            return _mapper.Map<TuristickaAgencija.Model.Zaposlenici>(entity);
        }

        public TuristickaAgencija.Model.Zaposlenici Update(int id, ZaposleniciInsertRequest request)
        {
            {
                var entity = _db.Zaposlenici.Where(x => x.ZaposlenikId == id).FirstOrDefault();

                _db.Zaposlenici.Attach(entity);

                _db.Zaposlenici.Update(entity);


                if (!string.IsNullOrWhiteSpace(request.Password))

                {
                    if (request.Password != request.PasswordPotvrda)

                    {
                        throw new Exception("Passwordi se ne slažu");

                    }

                    entity.LozinkaSalt = GenerateSalt();

                    entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

                }

                _mapper.Map(request, entity);


                _db.SaveChanges();


                return _mapper.Map<TuristickaAgencija.Model.Zaposlenici>(entity);
            }

        }
    }
}
