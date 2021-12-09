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
    public partial class PretplatePage : ContentPage
    {
        PretplateViewModel model = null;
        public PretplatePage()
        {
            InitializeComponent();
            BindingContext = model = new PretplateViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (await Application.Current.MainPage.DisplayAlert("Vaš 'Vivendi Travel'", "Da li ste sigurni?", "DA", "NE"))
            {
                var button = sender as Button;
                model.Pretplata = button.BindingContext as Pretplate;
                await model.Ukloni();
                await model.Init();
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (await Application.Current.MainPage.DisplayAlert("Vaš 'Vivendi Travel'", "Da li ste sigurni?", "DA", "NE"))
            {

                await model.Dodaj();
                await model.Init();
            }
        }
    }
}