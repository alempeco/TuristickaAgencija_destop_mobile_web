using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristickaAgencija.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KorisnickiProfilUrediPage : ContentPage
    {
        KorisnickiProfilUrediViewModel model = null;
        public KorisnickiProfilUrediPage()
        {
            InitializeComponent();
            BindingContext = model = new KorisnickiProfilUrediViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await model.Uredi();
            if (APIService.KorisnickoIme != this.KorisnickoIme.Text || !string.IsNullOrWhiteSpace(this.Lozinka.Text))
            {
                await Application.Current.MainPage.DisplayAlert("Vaš 'Vivendi Travel'!", "Uspjesno ste uredili podatke!", "OK");

                Application.Current.MainPage = new LoginPage();

            }
            else
                await Navigation.PopAsync();
        }
        async void OnImageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KorisnickiProfilPage());

        }
    }
}