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
    public partial class OcjeneKomentariPage : ContentPage
    {
        OcjeneKomentariViewModel model = null;
        public OcjeneKomentariPage()
        {
            InitializeComponent();
            BindingContext = model = new OcjeneKomentariViewModel();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KomentariPage());
        }

        private async void Button_Clicked2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OcjenePage());
        }
    }
}