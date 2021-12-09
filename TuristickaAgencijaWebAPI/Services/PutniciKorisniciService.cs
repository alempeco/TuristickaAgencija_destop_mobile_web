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
    public class PutniciKorisniciService : IPutniciKorisniciService
    {
        private readonly MyContext _db;
        private readonly IMapper _mapper;
        public PutniciKorisniciService(MyContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public List<TuristickaAgencija.Model.PutniciKorisnici> Get(PutniciKorisniciSearchRequest request)
        {
            var query = _db.PutniciKorisnici.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.ToLower().StartsWith(request.Ime.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.ToLower().StartsWith(request.Prezime.ToLower()));
            }
            var list = query.ToList();
            return _mapper.Map<List<TuristickaAgencija.Model.PutniciKorisnici>>(list);
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



        public TuristickaAgencija.Model.PutniciKorisnici AutentificirajPutnika(string username, string pass)
        {
            var user = _db.PutniciKorisnici.Where(x => x.KorisnickoIme == username).FirstOrDefault();


            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, pass);



                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<TuristickaAgencija.Model.PutniciKorisnici>(user);

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

        public TuristickaAgencija.Model.PutniciKorisnici GetById(int id)
        {
            var entity = _db.PutniciKorisnici.Find(id);


            return _mapper.Map<TuristickaAgencija.Model.PutniciKorisnici>(entity);

        }

        public TuristickaAgencija.Model.PutniciKorisnici Insert(PutniciKorisniciInsertRequest request)
        {
            var entity = _mapper.Map<Database.PutniciKorisnici>(request);


            if (request.Password != request.PasswordPotvrda)

            {
                throw new Exception("Passwordi se ne slažu");

            }

            entity.LozinkaSalt = GenerateSalt();

            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);


            _db.PutniciKorisnici.Add(entity);

            _db.SaveChanges();

            _db.SaveChanges();


            return _mapper.Map<TuristickaAgencija.Model.PutniciKorisnici>(entity);
        }

        public TuristickaAgencija.Model.PutniciKorisnici Update(int id, PutniciKorisniciInsertRequest request)
        {
            {
                var entity = _db.PutniciKorisnici.Where(x => x.PutnikKorisnikId == id).FirstOrDefault();

                _db.PutniciKorisnici.Attach(entity);

                _db.PutniciKorisnici.Update(entity);


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


                return _mapper.Map<TuristickaAgencija.Model.PutniciKorisnici>(entity);
            }
        }
    }
}
