using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.Mobile.ViewModels;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Requests;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristickaAgencija.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlatiOnlinePage : ContentPage
    {
        private decimal Tax = 0.17M;
       
        private APIService _service = new APIService("OnlinePay");
        UplateViewModel model = null;
        public PlatiOnlinePage()
        {
            InitializeComponent();
            BindingContext = model = new UplateViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void Finish_Clicked(object sender, EventArgs e)
        {
            var korisnicko = APIService.KorisnickoIme;
            string korisnickoIme = APIService.KorisnickoIme;

            var putnikID = 0;
            APIService _putniciService = new APIService("PutniciKorisnici");
            var putnici = await _putniciService.Get<List<PutniciKorisnici>>(null);
            foreach (var putnik in putnici)
            {
                if (putnik.KorisnickoIme == korisnicko)
                {
                    putnikID = putnik.PutnikKorisnikId;
                    break;
                }
            }
            //APIService _serviceRezervacije = new APIService("Rezervacije");
           
            //var uplate = await _service.Get<List<Uplate>>(null);
            //foreach (var u in uplate)
            //{
            //    if (putnikID == 0)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        var rezervacija = await _serviceRezervacije.GetById<Rezervacije>(u.RezervacijaId);
            //        if (rezervacija.PutnikKorisnikId == putnikID)
            //        {
            //            break;
            //        }
            //    }
            //}

            string textt = IznosEntry.Text;
            string svrha = SvrhaEntry.Text;
            OnlinePayInsertRequest request = new OnlinePayInsertRequest
            {
               DatumUplate=DateTime.Now,
               Iznos= float.Parse(textt),
               PutnikKorisnikId =putnikID,
               KorisnickoIme=korisnickoIme,
               Svrha=svrha
               
               

            };


            await _service.Insert<Model.OnlinePay>(request);

            //await DisplayAlert("Success", "You have successfully created an order", "OK");
           
            //lblArticleAmount.Text = "Article amount: 0";
            //lblValue.Text = "Price: 0 KM";
            
            await Navigation.PushAsync(new StripePaymentGatewayPage(request.Iznos));
        }
    }
}