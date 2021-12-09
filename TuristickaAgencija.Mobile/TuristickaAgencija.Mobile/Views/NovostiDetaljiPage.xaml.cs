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
    public partial class NovostiDetaljiPage : ContentPage
    {
        NovostiDetaljiViewModel model;
        public NovostiDetaljiPage(Novosti n)
        {
            InitializeComponent();
            BindingContext = model = new NovostiDetaljiViewModel()
            {
                Novost = n
            };
        }
        async void OnImageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovostiPutnikPage());

        }
    }
}