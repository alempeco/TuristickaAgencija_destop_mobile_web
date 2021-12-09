using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Mobile.Models
{
    public enum MenuItemTypeP
    {
        Pocetna,
        Termini,
        
        Preplate,
        OcjeneKomentari,
        
        Uplate,
        Pokusajuplate,
        OnlinePay,
        Odjava,
        Novosti,
        MojProfil,
        Rezervacije
        
       

    }
    public class HomeMenuItemPutnik
    {
        public MenuItemTypeP Id { get; set; }

        public string Title { get; set; }
    }
}
