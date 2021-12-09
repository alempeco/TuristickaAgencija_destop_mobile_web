using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Requests;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class PreporukaViewModel:BaseViewModel
    {
        public PreporukaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public List<TerminiPutovanja> ListPreporuceniTermini = new List<TerminiPutovanja>();
        public ObservableCollection<TerminiPutovanja> PreporuceniTermini { get; set; } = new ObservableCollection<TerminiPutovanja>();
       
        readonly APIService _terminiService = new APIService("TerminiPutovanja");
        readonly APIService _rezervacijeService = new APIService("Rezervacije");
        readonly APIService _vrstaPutoavanjaService = new APIService("VrstaPutovanja");
        readonly APIService _putovanjaService = new APIService("Putovanja");
        public ICommand InitCommand{ get; set; }
        public async Task Init()
        {
            var putnikId = 0;
            APIService _putniciService = new APIService("PutniciKorisnici");
            var putnici = await _putniciService.Get<List<PutniciKorisnici>>(null);
            foreach(var i in putnici)
            {
                if(i.KorisnickoIme==APIService.KorisnickoIme)
                {
                    putnikId = i.PutnikKorisnikId;
                    break;
                }
            }
            //pokupi sve rezervacije korisnika
            var rezervacije =await  _rezervacijeService.Get<List<Rezervacije>>(new RezervacijeSearchRequest
            {
                PutnikKorisnikId = putnikId
            });

            List<VrstaPutovanja> listVrste = await _vrstaPutoavanjaService.Get<List<VrstaPutovanja>>(null);

            List<Preporuka> preporukeList = new List<Preporuka>();




            if (rezervacije.Count > 0)
            {
                foreach (var vr in listVrste)
                {
                    int broj = 0;
                    foreach (var i in rezervacije)
                    {
                        var termin = await _terminiService.GetById<TerminiPutovanja>(i.TerminPutovanjaId);
                        var putovanje = await _putovanjaService.GetById<Putovanja>(termin.PutovanjeId);
                        var vrsta = await _vrstaPutoavanjaService.GetById<VrstaPutovanja>(putovanje.VrstaPutovanjaId);

                        if (vr.VrstaPutovanjaId == vrsta.VrstaPutovanjaId)
                        {
                            broj++;
                        }

                    }
                    preporukeList.Add(new Preporuka { VrstaPutovanjaId = vr.VrstaPutovanjaId, BrojRezervacija = broj });
                }

                preporukeList = preporukeList.OrderByDescending(a => a.BrojRezervacija).ToList();



                var putovanja = await _putovanjaService.Get<List<Putovanja>>(new PutovanjaSearchRequest
                {
                    VrstaPutovanjaId = preporukeList[0].VrstaPutovanjaId
                });
                var vrstaNajPos = await _vrstaPutoavanjaService.GetById<VrstaPutovanja>(preporukeList[0].VrstaPutovanjaId);
                VrstaPutovanjaOznaka = vrstaNajPos.Oznaka;

                ListPreporuceniTermini.Clear();
                foreach (var i in putovanja)
                {
                    var termini = await _terminiService.Get<List<TerminiPutovanja>>(new TerminiSearchRequest
                    {
                        PutovanjeId = i.PutovanjaId,
                        Aktivno = true
                    });
                    foreach (var j in termini)
                    {
                        if (j.DatumPolaska > DateTime.Now)
                        {
                            var rez = await _rezervacijeService.Get<List<Rezervacije>>(new RezervacijeSearchRequest
                            {
                                PutnikKorisnikId = putnikId,
                                TerminId = j.TerminPutovanjaId
                            });
                            if (rez.Count == 0)
                            {
                                ListPreporuceniTermini.Add(j);
                            }
                        }
                    }
                }
            }

            ListPreporuceniTermini = ListPreporuceniTermini.OrderByDescending(x => x.TerminPutovanjaId).ToList();
            PreporuceniTermini.Clear();
            foreach(var i in ListPreporuceniTermini)
            {
                PreporuceniTermini.Add(i);
            }
        }

        string _vrstaPutovanjaOznaka = string.Empty;
        public string VrstaPutovanjaOznaka
        {
            get { return _vrstaPutovanjaOznaka; }
            set { SetProperty(ref _vrstaPutovanjaOznaka, value); } 
        }



    }
}
