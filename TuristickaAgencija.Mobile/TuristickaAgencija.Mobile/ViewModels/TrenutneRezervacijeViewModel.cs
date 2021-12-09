using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Requests;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class TrenutneRezervacijeViewModel : BaseViewModel
    {
        public TrenutneRezervacijeViewModel()
        {
            InitCommand = new Command(async () => await Init());
            OtkaziCommand = new Command(async () => await Otkazi());
        }
        Rezervacije _rezervacijaOtkazi = null;
        public Rezervacije rezervacijaOtkazi
        {
            get { return _rezervacijaOtkazi; }
            set { SetProperty(ref _rezervacijaOtkazi, value); }
        }



        bool _rezervacijeMessage = false;
        public bool RezervacijeMessage
        {
            get { return _rezervacijeMessage; }
            set { SetProperty(ref _rezervacijeMessage, value); }
        }
        public ObservableCollection<Rezervacije> ListRezervacije { get; set; } = new ObservableCollection<Rezervacije>();
        readonly APIService _rezervacijeService = new APIService("Rezervacije");
        readonly APIService _terminService = new APIService("TerminiPutovanja");


        public ICommand InitCommand { get; set; }
        public ICommand OtkaziCommand { get; set; }
        public async Task Init()
        {
            ListRezervacije.Clear();
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

            RezervacijeSearchRequest search = null;

            if (putnikID != 0)
            {
                search = new RezervacijeSearchRequest { PutnikKorisnikId = putnikID };
            }



            var rezervacijeList = await _rezervacijeService.Get<List<Rezervacije>>(search);
            // samo aktualne- datum polaska nije prosao i one dolaze u obzir za otkazivanje

            ListRezervacije.Clear();
            foreach (var i in rezervacijeList)
            {
                var termin = await _terminService.GetById<TerminiPutovanja>(i.TerminPutovanjaId);
                if (termin.DatumPolaska > DateTime.Now)
                {
                    ListRezervacije.Add(i);
                }
            }
            if (ListRezervacije.Count == 0)
            {
                RezervacijeMessage = true;
            }


        }
        public async Task Otkazi()
        {
            // rezervacija se ne moze se otkazati 3 dana prije polaska na putovanje
            APIService _terminService = new APIService("TerminiPutovanja");
            var termin = await _terminService.GetById<TerminiPutovanja>(rezervacijaOtkazi.TerminPutovanjaId);

            if ((termin.DatumPolaska - DateTime.Now).TotalDays > 3)
            {
                var response = await Application.Current.MainPage.DisplayAlert("Vaš 'Vivendi Travel'", "Da li želite otkazati putovanje?", "DA", "NE");
                if (response)
                {
                    var response2 = await Application.Current.MainPage.DisplayAlert("Vaš 'Vivendi Travel'", "Da li ste sigurni?", "DA", "NE");
                    if (response2)
                    {
                        await _rezervacijeService.Delete<Rezervacije>(rezervacijaOtkazi.RezervacijaId);
                    }
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Vaš 'Vivendi Travel'", "Vrijeme za otkazivanje rezervacije je isteklo.", "OK");
            }
        }
    }
}
