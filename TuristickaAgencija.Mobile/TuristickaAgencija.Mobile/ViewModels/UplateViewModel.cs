using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class UplateViewModel : BaseViewModel
    {
        readonly APIService _serviceUplate = new APIService("Uplate");
        public ObservableCollection<Uplate> ListUplate { get; set; } = new ObservableCollection<Uplate>();
        public ICommand InitCommand { get; set; }
        float _iznos = 0;
        public float Iznos
        {
            get { return _iznos; }
            set { SetProperty(ref _iznos, value); }
        }
        public async Task Init()
        {
            var korisnicko = APIService.KorisnickoIme;

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
            APIService _serviceRezervacije = new APIService("Rezervacije");
            ListUplate.Clear();
            var uplate = await _serviceUplate.Get<List<Uplate>>(null);
            foreach (var u in uplate)
            {
                if (putnikID == 0)
                {
                    ListUplate.Add(u);
                }
                else
                {
                    var rezervacija = await _serviceRezervacije.GetById<Rezervacije>(u.RezervacijaId);
                    if (rezervacija.PutnikKorisnikId == putnikID)
                    {
                        ListUplate.Add(u);
                    }
                }
            }
        }
    }
}
