using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Mobile.Models
{
    public enum MenuItemType
    {
        
        Rezervacije,
        Uplate,
        MojProfil,
        Odjava

    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
