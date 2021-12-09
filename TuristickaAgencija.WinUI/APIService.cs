using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.Model;
using Flurl;


namespace TuristickaAgencija.WinUI
{
    public class APIService
    {
        public static string KorisnickoIme { get; set; }
        public static string Lozinka { get; set; }
        private string _route = null;
        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }
            return await url.WithBasicAuth(KorisnickoIme, Lozinka).GetJsonAsync<T>();

        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithBasicAuth(KorisnickoIme, Lozinka).GetJsonAsync<T>();

        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            return await url.WithBasicAuth(KorisnickoIme, Lozinka).PostJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithBasicAuth(KorisnickoIme, Lozinka).PutJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Delete<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithBasicAuth(KorisnickoIme, Lozinka).DeleteAsync().ReceiveJson<T>();

        }
    }
}
