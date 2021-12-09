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
    public partial class UplatePage : ContentPage
    {
        UplateViewModel model = null;
        public UplatePage()
        {
            InitializeComponent();
            BindingContext = model = new UplateViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new UplateInfoPage());
        //}
        async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new UplateInfoPage());
        }
        
        async void OnImageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UplateInfoPage());

        }
    }
}