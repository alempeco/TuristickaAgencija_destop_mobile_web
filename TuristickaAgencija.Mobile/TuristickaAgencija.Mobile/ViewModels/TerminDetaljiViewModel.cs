using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Requests;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class TerminDetaljiViewModel : BaseViewModel
    {
        public TerminDetaljiViewModel()
        {
            InitCommand = new Command(async () => await Init());
           
            RezervisiCommand = new Command(async () => await Rezervisi());
            //byte[] defaultPhoto = File.ReadAllBytes("noimage.png");
            //Slika = defaultPhoto;

        }
        public TerminiPutovanja TerminPutovanja { get; set; }

        public ObservableCollection<Vodici> ListVodici { get; set; } = new ObservableCollection<Vodici>();
       


        private byte[] _slika = null;
        public byte[] Slika
        {
            get { return _slika; }
            set { SetProperty(ref _slika, value); }
        }

        double _ocjena = 0;
        public double Ocjena
        {
            get { return _ocjena; }
            set { SetProperty(ref _ocjena, value); }
        }
        bool _ocjenaBool = true;
        public bool OcjenaBool
        {
            get { return _ocjenaBool; }
            set { SetProperty(ref _ocjenaBool, value); }
        }

       

        readonly APIService _terminiService = new APIService("TerminiPutovanja");
        readonly APIService _ocjeneService = new APIService("OcjenePutovanja");

       
        readonly APIService _rezervacijeService = new APIService("Rezervacije");




        public ICommand InitCommand { get; set; }
        public ICommand UrediCommand { get; set; }
        public ICommand RezervisiCommand { get; set; }
        int putnikID = 0;

        public async Task Init()
        {

           

            var ocjene = await _ocjeneService.Get<List<OcjenePutovanja>>(new OcjenePutovanjaSearchRequest { PutovanjeId = TerminPutovanja.PutovanjeId });
            var sumOcjene = 0;
            foreach (var i in ocjene)
            {
                sumOcjene += (int)i.OcjenaId;
            }
            if (ocjene.Count == 0)
            {
                Ocjena = 0;
                OcjenaBool = false;
            }
            else
            {
                Ocjena = sumOcjene / ocjene.Count;
            }
           


        }
        
        public async Task Rezervisi()
        {
            var korisnicko = APIService.KorisnickoIme;
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

            List<Rezervacije> rezervacije = await _rezervacijeService.Get<List<Rezervacije>>(new RezervacijeSearchRequest
            {
                TerminId = TerminPutovanja.TerminPutovanjaId
            });
            //broj mjesta i broj rezervacija!!
            if (TerminPutovanja.BrojMjesta > rezervacije.Count)
            {


                await _rezervacijeService.Insert<Rezervacije>(new RezervacijeInsertRequest
                {
                    PutnikKorisnikId = putnikID,
                    TerminPutovanjaId = TerminPutovanja.TerminPutovanjaId,
                    Vrijeme = DateTime.Now
                });
                await Application.Current.MainPage.DisplayAlert("Vaš 'Vivendi Travel'!", "Uspješno ste rezervisali putovanje, SRETAN PUT!", "OK");

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Vaš 'Vivendi Travel'", "Žao nam je, popunjen je predviđeni broj mjesta! ", "OK");

            }
        }
    }
}
