using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TuristickaAgencija.Mobile.Models;
using TuristickaAgencija.Mobile.ViewModels;

namespace TuristickaAgencija.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();


        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            //MenuPages.Add((int)MenuItemType.Termini, (NavigationPage)Detail);

        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    
                    case (int)MenuItemType.Uplate:
                        MenuPages.Add(id, new NavigationPage(new ZaposlenikUplateInfoPage()));
                        break;
                    case (int)MenuItemType.MojProfil:
                        MenuPages.Add(id, new NavigationPage(new KorisnickiProfilPage()));
                        break;
                    case (int)MenuItemType.Rezervacije:
                        MenuPages.Add(id, new NavigationPage(new ZaposlenikRezervacijaPage()));
                        break;
                   
                    case (int)MenuItemType.Odjava:
                        MenuPages.Add(id, new NavigationPage(new OdjavaPage()));
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