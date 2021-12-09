using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Requests;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class KorisnickiProfilUrediViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Zaposlenici");
        private readonly APIService _servicePutnik = new APIService("PutniciKorisnici");

        public Zaposlenici Zaposlenik = null;
        public PutniciKorisnici Putnik = null;


        public KorisnickiProfilUrediViewModel()

        {

            InitCommand = new Command(async () => await Init());

            RegistrationCommand = new Command(async () => await Uredi());

        }
        public ICommand RegistrationCommand { get; set; }

        public ICommand InitCommand { get; set; }

        bool IsPutnik = false;
        public async Task Init()

        {
            var korisnicko = APIService.KorisnickoIme;

            var zaposlenici = await _service.Get<List<Zaposlenici>>(null);
            var putnici = await _servicePutnik.Get<List<PutniciKorisnici>>(null);

            foreach (var z in zaposlenici)
            {
                if (z.KorisnickoIme == korisnicko)
                {
                    Zaposlenik = z;
                    Ime = z.Ime;
                    Prezime = z.Prezime;
                    Kontakt = z.Kontakt;
                    Email = z.Email;
                    KorisnickoIme = z.KorisnickoIme;
                    break;
                }
            }
            foreach (var z in putnici)
            {
                if (z.KorisnickoIme == korisnicko)
                {
                    IsPutnik = true;

                    Putnik = z;
                    Ime = z.Ime;
                    Prezime = z.Prezime;
                    Kontakt = z.Kontakt;
                    Email = z.Email;
                    KorisnickoIme = z.KorisnickoIme;
                    break;
                }
            }
        }

        public async Task Uredi()
        {
            IsBusy = true; 
            //mozda i sliku?
            if (IsPutnik == false)
            {
                await _service.Update<Zaposlenici>(Zaposlenik.ZaposlenikId, new ZaposleniciInsertRequest()
                {

                    Ime = _ime,
                    Prezime = _prezime,

                    Kontakt = _kontakt,
                    Email = _email,
                    KorisnickoIme = _korisnickoIme,
                    Password = _lozinka,
                    PasswordPotvrda = _potvrdaLozinke
                });
            }
            else
            {
                await _servicePutnik.Update<PutniciKorisnici>(Putnik.PutnikKorisnikId, new PutniciKorisniciInsertRequest()
                {

                    Ime = _ime,
                    Prezime = _prezime,
                    Kontakt = _kontakt,
                    Email = _email,
                    KorisnickoIme = _korisnickoIme,
                    Password = _lozinka,
                    PasswordPotvrda = _potvrdaLozinke
                });
            }

            await Application.Current.MainPage.DisplayAlert("Vaš 'Vivendi Travel'", "Uspjesno ste uredili svoj profil!", "OK");


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

        string _kontakt = string.Empty;
        public string Kontakt
        {
            get { return _kontakt; }
            set { SetProperty(ref _kontakt, value); }
        }
        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
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
        string _potvrdaLozinke = string.Empty;
        public string PotvrdaLozinke
        {
            get { return _potvrdaLozinke; }
            set { SetProperty(ref _potvrdaLozinke, value); }
        }


    }
}
