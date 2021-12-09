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
    public class KomentariOcjenaViewModel : BaseViewModel
    {
        public KomentariOcjenaViewModel()
        {
            InitCommand = new Command(async () => await Init());
            DodajCommand = new Command(async () => await Dodaj());
        }
        public Putovanja Putovanje { get; set; }
        public ObservableCollection<Komentari> ListKomentari { get; set; } = new ObservableCollection<Komentari>();
        public ObservableCollection<Ocjene> ListOcjene { get; set; } = new ObservableCollection<Ocjene>();


        readonly APIService _serviceKomentari = new APIService("Komentari");
        readonly APIService _serviceOcjene = new APIService("OcjenePutovanja");
        readonly APIService _serviceOcjene2 = new APIService("Ocjene");

        double _prosjecnaOcjena = 0;
        public double ProsjecnaOcjena
        {
            get { return _prosjecnaOcjena; }
            set { SetProperty(ref _prosjecnaOcjena, value); }

        }

        Ocjene _ocjenaSelected = null;
        public Ocjene Ocjena
        {
            get { return _ocjenaSelected; }
            set { SetProperty(ref _ocjenaSelected, value); }
        }
        string _komentar = string.Empty;
        public string KomentarSadrzaj
        {
            get { return _komentar; }
            set { SetProperty(ref _komentar, value); }
        }

        public ICommand InitCommand { get; set; }
        public ICommand DodajCommand { get; set; }
        public async Task Init()
        {

            var komentari = await _serviceKomentari.Get<List<Komentari>>(new KomentariSearchRequest
            {
                PutovanjeId = Putovanje.PutovanjaId
            });
            ListKomentari.Clear();
            foreach (var i in komentari)
            {
                ListKomentari.Add(i);
            }
            var ocjene2 = await _serviceOcjene2.Get<List<Ocjene>>(null);
            ListOcjene.Clear();
            foreach (var i in ocjene2)
            {
                ListOcjene.Add(i);
            }


            var ocjene = await _serviceOcjene.Get<List<OcjenePutovanja>>(new OcjenePutovanjaSearchRequest
            {
                PutovanjeId = Putovanje.PutovanjaId
            });
            int sumOcjena = 0;
            foreach (var i in ocjene)
            {
                sumOcjena += (int)i.OcjenaId;
            }
            if (ocjene.Count > 0)
            {
                ProsjecnaOcjena = sumOcjena / ocjene.Count;
            }
        }

        public async Task Dodaj()
        {
            var putnikid = 0;
            var korisnicko = APIService.KorisnickoIme;
            APIService _apikorisnici = new APIService("PutniciKorisnici");
            var putnici = await _apikorisnici.Get<List<PutniciKorisnici>>(null);
            foreach (var i in putnici)
            {
                if (i.KorisnickoIme == korisnicko)
                {
                    putnikid = i.PutnikKorisnikId;
                    break;

                }
            }
            if (KomentarSadrzaj.Length > 0)
            {
                await _serviceKomentari.Insert<Komentari>(new KomentariInsertRequest
                {
                    Sadrzaj = KomentarSadrzaj,
                    PutnikKorisnikId = putnikid,
                    Vrijeme = DateTime.Now,
                    PutovanjeId = Putovanje.PutovanjaId

                });
            }
            if (Ocjena != null)
                await _serviceOcjene.Insert<OcjenePutovanja>(new OcjenePutovanjaInsertRequest
                {
                    PutnikKorisnikId = putnikid,
                    PutovanjeId = Putovanje.PutovanjaId,
                    OcjenaId = Ocjena.OcjenaId
                });

        }
    }
}
