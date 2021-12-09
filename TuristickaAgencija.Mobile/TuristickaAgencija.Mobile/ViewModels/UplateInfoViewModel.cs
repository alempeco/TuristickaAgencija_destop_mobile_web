using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Requests;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class UplateInfoViewModel : BaseViewModel
    {
        public UplateInfoViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        readonly APIService _serviceUplate = new APIService("Uplate");

        double _placenoSuma = 0;
        public double PlacenoSuma
        {
            get { return _placenoSuma; }
            set { SetProperty(ref _placenoSuma, value); }
        }
        double _nijePlacenoSuma = 0;
        public double NijePlacenoSuma
        {
            get { return _nijePlacenoSuma; }
            set { SetProperty(ref _nijePlacenoSuma, value); }
        }
        int _brojUplata = 0;
        public int BrojUplata
        {
            get { return _brojUplata; }
            set { SetProperty(ref _brojUplata, value); }
        }



        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            BrojUplata = 0;
            NijePlacenoSuma = 0;
            PlacenoSuma = 0;
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

            var uplate = await _serviceUplate.Get<List<Uplate>>(null);
            int brojUplata = 0;
            foreach (var i in uplate)
            {
                var rez = await _serviceRezervacije.GetById<Rezervacije>(i.RezervacijaId);
                if (rez.PutnikKorisnikId == putnikID)
                {
                    PlacenoSuma += i.Iznos;
                    brojUplata++;
                }

            }

            BrojUplata = brojUplata;
            APIService _serviceTermini = new APIService("TerminiPutovanja");


            var rezervacije = await _serviceRezervacije.Get<List<Rezervacije>>(new RezervacijeSearchRequest
            {
                PutnikKorisnikId = putnikID
            });
            double terminiPotrebanIznos = 0;

            foreach (var i in rezervacije)
            {
                var termin = await _serviceTermini.GetById<TerminiPutovanja>(i.TerminPutovanjaId);

                terminiPotrebanIznos += (double)termin.Cijena;
            }
            NijePlacenoSuma = terminiPotrebanIznos - PlacenoSuma;
            if (NijePlacenoSuma < 0)
            {
                NijePlacenoSuma = 0;
            }
        }

    }
}
