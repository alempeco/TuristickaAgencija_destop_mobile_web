using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Mobile.Views;
using TuristickaAgencija.Model;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        readonly APIService _service = new APIService("Zaposlenici");
        readonly APIService _servicePutnici = new APIService("PutniciKorisnici");
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }
        string _korisnickoIme = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
        }

        string _lozinka = string.Empty;
        public string Lozinka
        {
            get { return _lozinka; }
            set { SetProperty(ref _lozinka, value); }
        }
        public ICommand LoginCommand { get; set; }
        async Task Login()
        {
            IsBusy = true;
            APIService.KorisnickoIme = KorisnickoIme;
            APIService.Lozinka = Lozinka;
            try
            {
                await _service.Get<dynamic>(null);

                //Application.Current.MainPage = new MainPage();
                PutniciKorisnici p = null;
                List<PutniciKorisnici> lista = await _servicePutnici.Get<List<PutniciKorisnici>>(null);
                foreach (var putnik in lista)
                {
                    if (putnik.KorisnickoIme == KorisnickoIme)
                    {
                        p = putnik;
                        break;
                    }
                }
                if (p != null)
                {
                    Application.Current.MainPage = new MainPagePutnik();// id na putnika
                }
                else
                {
                    Application.Current.MainPage = new MainPage();//id na zaposlenika
                    

                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
