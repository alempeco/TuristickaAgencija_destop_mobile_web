using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Mobile.Views;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Requests;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class RegistracijaViewModel : BaseViewModel
    {
        public RegistracijaViewModel()
        {
            RegistrationCommand = new Command(async () => await Registration());

        }


        public ICommand RegistrationCommand { get; set; }


        private readonly APIService _service = new APIService("PutniciKorisnici");



        public async Task Registration()
        {
            IsBusy = true;

            //osiguranje da li postoji korisnik sa tim imenom vec...kako ne bi doslo do konflikta prilikom online uplate
            var putniciKorisnici = await _service.Get<List<PutniciKorisnici>>(null);
            bool postoji = false;
            foreach (var i in putniciKorisnici)
            {
                if (i.KorisnickoIme == _korisnickoIme)
                {
                    postoji = true;
                    break;
                }

            }
            if (!postoji)
            {
                await _service.Insert<PutniciKorisnici>(new PutniciKorisniciInsertRequest()
                {
                    Ime = _ime,
                    Prezime = _prezime,
                    Kontakt = _kontakt,
                    Email = _email,
                    KorisnickoIme = _korisnickoIme,
                    Password = _lozinka,
                    PasswordPotvrda = _potvrdaLozinke,

                });
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Vaš 'Vivendi Travel'", "Pokušajte koristiti drugo korisničko ime!", "OK");

            }
            Application.Current.MainPage = new LoginPage();
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
