using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristickaAgencija.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPagePutnik : ContentPage
    {

        MainPagePutnik RootPage { get => Application.Current.MainPage as MainPagePutnik; }
        List<HomeMenuItemPutnik> menuItems;
        public MenuPagePutnik()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItemPutnik>
            {
                new HomeMenuItemPutnik {Id = MenuItemTypeP.Pocetna, Title="Početna" },
                new HomeMenuItemPutnik {Id = MenuItemTypeP.Termini, Title="Aktuelna putovanja" },
                new HomeMenuItemPutnik {Id = MenuItemTypeP.Novosti, Title="Novosti" },
                new HomeMenuItemPutnik {Id = MenuItemTypeP.Rezervacije, Title="Moje rezervacije" },
                new HomeMenuItemPutnik {Id = MenuItemTypeP.Uplate, Title="Uplate" },
                new HomeMenuItemPutnik {Id = MenuItemTypeP.OcjeneKomentari, Title="Prethodne aktivnosti" },
                new HomeMenuItemPutnik {Id = MenuItemTypeP.Preplate, Title="Pretplate" },
                //new HomeMenuItemPutnik {Id = MenuItemTypeP.Pokusajuplate, Title="Plati online" },                
                new HomeMenuItemPutnik {Id = MenuItemTypeP.MojProfil, Title="Uredi profil" },
                new HomeMenuItemPutnik {Id = MenuItemTypeP.Odjava, Title="Odjavi se" },



            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItemPutnik)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}
