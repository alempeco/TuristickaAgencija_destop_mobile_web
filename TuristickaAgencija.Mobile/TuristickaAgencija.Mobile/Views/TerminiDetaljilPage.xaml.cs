using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.Mobile.ViewModels;
using TuristickaAgencija.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristickaAgencija.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TerminiDetaljilPage : ContentPage
    {
        TerminDetaljiViewModel model = null;
        public TerminiDetaljilPage(TerminiPutovanja t)
        {
            InitializeComponent();
            BindingContext = model = new TerminDetaljiViewModel()
            {
                TerminPutovanja = t,
                Slika = t.Slika
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await model.Init();

        }


        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var res = await Application.Current.MainPage.DisplayAlert("Vaš 'Vivendi Travel'!", "Da li želite potvrditi rezervaciju?", "DA", "NE");
            if (res)
            {
                await model.Rezervisi();
                await Navigation.PushAsync(new AktivniTerminiPage());
            }
            else
            {
                await Navigation.PushAsync(new TerminiDetaljilPage(model.TerminPutovanja));
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            APIService _api = new APIService("Putovanja");
            Putovanja p = await _api.GetById<Putovanja>(model.TerminPutovanja.PutovanjeId);
            await Navigation.PushAsync(new KomentarOcjenaDodajPage(p));

        }

        async void OnImageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AktivniTerminiPage());

        }
    }
}