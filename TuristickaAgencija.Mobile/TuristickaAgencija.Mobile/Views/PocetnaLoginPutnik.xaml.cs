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
    public partial class PocetnaLoginPutnik : ContentPage
    {
        PreporukaViewModel model = null;
        public PocetnaLoginPutnik()
        {
            InitializeComponent();
            BindingContext = model = new PreporukaViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            var item = button.BindingContext as TerminiPutovanja;
            Navigation.PushAsync(new TerminiDetaljilPage(item));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PretplatePage());
        }
    }
}