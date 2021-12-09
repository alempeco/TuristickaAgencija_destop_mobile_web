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
    public partial class ZaposlenikUplateInfoPage : ContentPage
    {
        ZaposlenikUplateInfo model = null;
        public ZaposlenikUplateInfoPage()
        {
            InitializeComponent();
            BindingContext = model = new ZaposlenikUplateInfo();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ZaposlenikUplatePage());
        }
    }
}