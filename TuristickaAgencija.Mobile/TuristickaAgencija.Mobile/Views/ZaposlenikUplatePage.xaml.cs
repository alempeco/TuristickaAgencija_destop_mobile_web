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
    public partial class ZaposlenikUplatePage : ContentPage
    {
        ZaposlenikUplateViewModel model = null;
        public ZaposlenikUplatePage()
        {
            InitializeComponent();
            BindingContext = model = new ZaposlenikUplateViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}