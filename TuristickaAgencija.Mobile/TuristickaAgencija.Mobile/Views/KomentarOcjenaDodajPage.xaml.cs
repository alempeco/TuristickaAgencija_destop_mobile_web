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
    public partial class KomentarOcjenaDodajPage : ContentPage
    {
        KomentariOcjenaViewModel model = null;
        public KomentarOcjenaDodajPage(Putovanja p)
        {
            InitializeComponent();
            BindingContext = model = new KomentariOcjenaViewModel()
            {
                Putovanje = p
            };

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {

            await model.Dodaj();

            await Navigation.PushAsync(new TerminKomentariOcjenaPage(model.Putovanje));
        }
    }
}