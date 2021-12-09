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
    public class PretplateViewModel : BaseViewModel
    {
        public PretplateViewModel()
        {
            InitCommand = new Command(async () => await Init());
            UkloniCommand = new Command(async () => await Ukloni());
            DodajCommand = new Command(async () => await Dodaj());
        }
        public ObservableCollection<Pretplate> ListPretplate { get; set; } = new ObservableCollection<Pretplate>();
        public ObservableCollection<VrstaPutovanja> ListVrstaPutovanja { get; set; } = new ObservableCollection<VrstaPutovanja>();

        readonly APIService _servicePretplate = new APIService("Pretplate");
        readonly APIService _serviceVrstaPutovanja = new APIService("VrstaPutovanja");

        Pretplate _pretplata = null;
        public Pretplate Pretplata
        {
            get { return _pretplata; }
            set { SetProperty(ref _pretplata, value); }
        }

        VrstaPutovanja _vrsta = null;
        public VrstaPutovanja Vrsta
        {
            get { return _vrsta; }
            set { SetProperty(ref _vrsta, value); }
        }

        public ICommand InitCommand { get; set; }
        public ICommand UkloniCommand { get; set; }
        public ICommand DodajCommand { get; set; }
        public async Task Init()
        {
            var putnikid = 0;
            APIService _apiPutnici = new APIService("PutniciKorisnici");
            var putnici = await _apiPutnici.Get<List<PutniciKorisnici>>(null);
            foreach (var i in putnici)
            {
                if (APIService.KorisnickoIme == i.KorisnickoIme)
                {
                    putnikid = i.PutnikKorisnikId;
                    break;
                }
            }
            var pretplateKorisnika = await _servicePretplate.Get<List<Pretplate>>(new PretplateSearchRequest
            {
                PutnikKorisnikId = putnikid
            });

            ListPretplate.Clear();
            foreach (var i in pretplateKorisnika)
            {
                ListPretplate.Add(i);
            }

            //lista vrstaPutovanja koje korisnik nema
            var vrstaputovanja = await _serviceVrstaPutovanja.Get<List<VrstaPutovanja>>(null);
            ListVrstaPutovanja.Clear();
            foreach (var i in vrstaputovanja)
            {
                bool postoji = false;
                foreach (var j in pretplateKorisnika)
                {
                    if (i.VrstaPutovanjaId == j.VrstaPutovanjaId)
                    {
                        postoji = true;
                    }
                }
                if (!postoji)
                {
                    ListVrstaPutovanja.Add(i);
                }
            }


        }

        public async Task Ukloni()
        {
            await _servicePretplate.Delete<Pretplate>(Pretplata.PretplataId);
        }
        public async Task Dodaj()
        {
            var putnikid = 0;
            APIService _apiPutnici = new APIService("PutniciKorisnici");
            var putnici = await _apiPutnici.Get<List<PutniciKorisnici>>(null);
            foreach (var i in putnici)
            {
                if (APIService.KorisnickoIme == i.KorisnickoIme)
                {
                    putnikid = i.PutnikKorisnikId;
                    break;
                }
            }
            var vrsta = await _serviceVrstaPutovanja.GetById<VrstaPutovanja>(Vrsta.VrstaPutovanjaId);
            await _servicePretplate.Insert<Pretplate>(new PretplateInsertRequest
            {
                PutnikKorisnikId = putnikid,
                VrstaPutovanjaId = vrsta.VrstaPutovanjaId
            });
        }

    }
}
