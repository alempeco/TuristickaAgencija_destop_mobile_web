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
    public partial class KomentariPage : ContentPage
    {
        OcjeneKomentariViewModel model = null;
        public KomentariPage()
        {
            InitializeComponent();
            BindingContext = model = new OcjeneKomentariViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Komentari;
            APIService _service = new APIService("Putovanja");
            Putovanja entity = await _service.GetById<Putovanja>(item.PutovanjeId);
            await Navigation.PushAsync(new TerminKomentariOcjenaPage(entity));


        }
    }
}