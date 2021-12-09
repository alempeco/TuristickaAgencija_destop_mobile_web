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
    public partial class MainPagePutnik : MasterDetailPage
    {
        public MainPagePutnik()
        {
            InitializeComponent();
            //MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            MasterBehavior = MasterBehavior.Popover;
            //MenuPages.Add((int)MenuItemTypeP.Termini, (NavigationPage)Detail);

            Title = "Početna";
        }

        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemTypeP.Pocetna:
                        MenuPages.Add(id, new NavigationPage(new PocetnaLoginPutnik()));
                        break;
                    case (int)MenuItemTypeP.Termini:
                        MenuPages.Add(id, new NavigationPage(new AktivniTerminiPage()));
                        break;
                    
                        //     case (int)MenuItemTypeP.Pokusajuplate:
                        //MenuPages.Add(id, new NavigationPage(new PlatiOnlinePage()));
                        //break;


                    case (int)MenuItemTypeP.Uplate:
                        MenuPages.Add(id, new NavigationPage(new UplateInfoPage()));
                        break;
                    case (int)MenuItemTypeP.OcjeneKomentari:
                        MenuPages.Add(id, new NavigationPage(new OcjeneKomentariPage()));
                        break;
                    case (int)MenuItemTypeP.Preplate:
                        MenuPages.Add(id, new NavigationPage(new PretplatePage()));
                        break;
                   

                    case (int)MenuItemTypeP.Odjava:
                        MenuPages.Add(id, new NavigationPage(new OdjavaPage()));
                        break;
                    case (int)MenuItemTypeP.Rezervacije:
                        MenuPages.Add(id, new NavigationPage(new TrenutneRezervacijePage()));
                        break;
                    case (int)MenuItemTypeP.Novosti:
                        MenuPages.Add(id, new NavigationPage(new NovostiPutnikPage()));
                        break;
                    case (int)MenuItemTypeP.MojProfil:
                        MenuPages.Add(id, new NavigationPage(new KorisnickiProfilPage()));
                        break;



                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

    }
}