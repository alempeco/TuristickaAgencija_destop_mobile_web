using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TuristickaAgencija.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristickaAgencija.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistracijaPage : ContentPage
    {

        RegistracijaViewModel model = null;
        public RegistracijaPage()
        {
            InitializeComponent();
            BindingContext = model = new RegistracijaViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Ime.Text, @"^[a-zA-Z]+$"))
            {
                await DisplayAlert("Greška", "Ime se sastoji samo od slova", "OK");
            }
            else if (!Regex.IsMatch(this.Prezime.Text, @"^[a-zA-Z]+$"))
            {
                await DisplayAlert("Greška", "Prezime se sastoji samo od slova", "OK");
            }
            else if (!Regex.IsMatch(this.Kontakt.Text, @"^[+]{1}\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{3}"))
            {
                await DisplayAlert("Greška", "Format telefona je: +123 45 678 910", "OK");
            }
            else if (!Regex.IsMatch(this.Email.Text, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
            {
                await DisplayAlert("Greška", "Neispravan format email-a!", "OK");

            }
            else if (!Regex.IsMatch(this.KorisnickoIme.Text, @"^(?=.{4,40}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$"))
            {
                await DisplayAlert("Greška", "Neispravan format ili dužina korisničkog imena (4-40)", "OK");
            }
            else if (string.IsNullOrWhiteSpace(this.Password.Text))
            {
                await DisplayAlert("Greška", "Morate unijeti lozinku", "OK");

            }
            else if (this.Password.Text != this.PasswordPotvrda.Text)
            {
                await DisplayAlert("Greška", "Lozinke moraju biti iste", "OK");

            }
            else if (this.Password.Text.Length < 4)
            {
                await DisplayAlert("Greška", "Lozinka ne smije biti kraća od 4 karaktera", "OK");
            }
            else
            {
                try
                {
                    model.Ime = this.Ime.Text;
                    model.Prezime = this.Prezime.Text;
                    model.Kontakt = this.Kontakt.Text;
                    model.Email = this.Email.Text;
                    model.KorisnickoIme = this.KorisnickoIme.Text;
                    model.Lozinka = this.Password.Text;
                    model.PotvrdaLozinke = this.PasswordPotvrda.Text;

                    await model.Registration();
                }

                catch (Exception err)
                {
                    throw new Exception(err.Message);
                    //}Flurl.Http.FlurlHttpException: 'Call failed with status code 404 (Not Found): POST http://localhost:40088/api/PutniciKorisnici'
                }
            }
        }
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}