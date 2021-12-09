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
    public class OcjeneKomentariViewModel : BaseViewModel
    {
        public OcjeneKomentariViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        readonly APIService _serviceOcjene = new APIService("OcjenePutovanja");
        readonly APIService _serviceKomentari = new APIService("Komentari");

        public ObservableCollection<OcjenePutovanja> ListOcjene { get; set; } = new ObservableCollection<OcjenePutovanja>();
        public ObservableCollection<Komentari> ListKomentari { get; set; } = new ObservableCollection<Komentari>();

        bool _ocjenaMessage = false;
        public bool OcjenaMessage
        {
            get { return _ocjenaMessage; }
            set { SetProperty(ref _ocjenaMessage, value); }
        }

        public ICommand InitCommand { get; set; }
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

            var ocjene = await _serviceOcjene.Get<List<OcjenePutovanja>>(new OcjenePutovanjaSearchRequest
            {
                PutnikKorisnikId = putnikID
            });

            if (ocjene.Count == 0)
            {
                OcjenaMessage = true;
            }
            else
            {
                OcjenaMessage = false;
            }

            ListOcjene.Clear();
            foreach (var i in ocjene)
            {
                ListOcjene.Add(i);
            }

            var komentari = await _serviceKomentari.Get<List<Komentari>>(new KomentariSearchRequest
            {
                PutnikKorisikId = putnikID
            });
            ListKomentari.Clear();
            foreach (var i in komentari)
            {
                ListKomentari.Add(i);
            }
        }
    }
}
