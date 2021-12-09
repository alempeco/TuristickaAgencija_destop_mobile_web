using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.Model;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile
{
    public class APIService
    {
        public static string KorisnickoIme { get; set; }
        public static string Lozinka { get; set; }
        private string _route = null;

#if DEBUG
        private string _apiUrl = "http://localhost:40088/api";
#endif
#if RELEASE
        private string _apiUrl = "https://mojwebsite.com/api";
#endif

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}";
            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(KorisnickoIme, Lozinka).GetJsonAsync<T>();
            }
            catch(FlurlHttpException ex)
            {
                if(ex.Call.HttpStatus==System.Net.HttpStatusCode.Unauthorized)
                {
                   await Application.Current.MainPage.DisplayAlert("Greska","Niste autentificirani!","OK");
                }
                throw;
            }
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(KorisnickoIme, Lozinka).GetJsonAsync<T>();

        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";

            return await url.WithBasicAuth(KorisnickoIme, Lozinka).PostJsonAsync(request).ReceiveJson<T>();
            //return await url.PostJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(KorisnickoIme, Lozinka).PutJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Delete<T>(int id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";
           
            return await url.WithBasicAuth(KorisnickoIme, Lozinka).DeleteAsync().ReceiveJson<T>();

        }
    }
}
