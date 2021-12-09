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
    public partial class AktivniTerminiPage : ContentPage
    {
        AktivniTerminiViewModel model = null;

        public AktivniTerminiPage()
        {
            InitializeComponent();
            BindingContext = model = new AktivniTerminiViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await model.Init();

        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as TerminiPutovanja;

            await Navigation.PushAsync(new TerminiDetaljilPage(item));

        }


    }
}