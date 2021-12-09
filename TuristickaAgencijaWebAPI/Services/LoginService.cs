using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencijaWebAPI.Database;

namespace TuristickaAgencijaWebAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly MyContext _db;
        private readonly IMapper _mapper;
        public LoginService(MyContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public TuristickaAgencija.Model.KorisnikLogin Autentificiraj(string username, string pass)
        {
            var user = _db.Zaposlenici.Where(x => x.KorisnickoIme == username).FirstOrDefault();


            if (user != null)

            {
                var newHash = GenerateHash(user.LozinkaSalt, pass);



                if (newHash == user.LozinkaHash)
                {

                    return _mapper.Map<TuristickaAgencija.Model.KorisnikLogin>(user);

                }
            }
            return null;
        }

        public TuristickaAgencija.Model.KorisnikLogin AutentificirajPutnika(string username, string pass)
        {
            var user = _db.PutniciKorisnici.Where(x => x.KorisnickoIme == username).FirstOrDefault();


            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, pass);



                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<TuristickaAgencija.Model.KorisnikLogin>(user);

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
    }
}
