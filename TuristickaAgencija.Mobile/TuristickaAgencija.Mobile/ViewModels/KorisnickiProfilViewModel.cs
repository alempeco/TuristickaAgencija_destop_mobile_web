using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class KorisnickiProfilViewModel : BaseViewModel
    {

        private readonly APIService _apiservice = new APIService("Zaposlenici");
        private readonly APIService _apiservicePutnici = new APIService("PutniciKorisnici");

        public KorisnickiProfilViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }
        public ICommand InitCommand { get; set; }
        public Zaposlenici Zaposlenik = null;
        public PutniciKorisnici Putnik = null;


        public async Task Init()
        {
            var korisnicko = APIService.KorisnickoIme;
            var list = await _apiservice.Get<List<Zaposlenici>>(null);
            var listPutnici = await _apiservicePutnici.Get<List<PutniciKorisnici>>(null);
            foreach (var zaposlenik in list)
            {
                if (zaposlenik.KorisnickoIme == korisnicko)
                {
                    Ime = zaposlenik.Ime;
                    Prezime = zaposlenik.Prezime;
                    break;
                }
            }
            foreach (var i in listPutnici)
            {
                if (i.KorisnickoIme == korisnicko)
                {
                    Ime = i.Ime;
                    Prezime = i.Prezime;
                    break;
                }
            }
        }
        string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }
        string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }




    }
}
