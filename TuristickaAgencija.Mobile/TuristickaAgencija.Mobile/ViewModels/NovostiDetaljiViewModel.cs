using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Mobile.Views;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Requests;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class NovostiDetaljiViewModel:BaseViewModel
    {

        public Novosti Novost { get; set; }
        public ObservableCollection<Putovanja> listPutovanja { get; set; } = new ObservableCollection<Putovanja>();

        public NovostiDetaljiViewModel()
        {
            InitCommand = new Command(async() => await Init());
            UrediCommand = new Command(async () => await Uredi());
            ////byte[] defaultPhoto = File.ReadAllBytes("noimage.png");
            //Slika = defaultPhoto;
        }
        private readonly APIService _putovanja = new APIService("Putovanja");
        private readonly APIService _novosti = new APIService("Novosti");

        private byte[] _slika;
        public byte[] Slika
        {
            get { return _slika; }
            set { SetProperty(ref _slika, value); }
        }

        Putovanja _putovanje=null;
        public Putovanja PutovanjeSelected
        {
            get { return _putovanje; }
            set { SetProperty(ref _putovanje, value); }
        }


        public ICommand InitCommand { get; set; }
        public ICommand UrediCommand { get; set; }
        public async Task Init()
        {
            if (listPutovanja.Count == 0)
            {
                var list = await _putovanja.Get<IEnumerable<Putovanja>>(null);
                listPutovanja.Clear();

                foreach (var putovanje in list)
                {
                    listPutovanja.Add(putovanje);
                }
            }
         



        }
        public async Task Uredi()
        {
        
            IsBusy = true;
           
            APIService _zaposlenik = new APIService("Zaposlenici");
            var zaposlenici = await _zaposlenik.Get<List<Zaposlenici>>(null);

            int zaposlenikId = 0;
            foreach(var i in zaposlenici)
            {
                if(i.KorisnickoIme==APIService.KorisnickoIme)
                {
                    zaposlenikId = i.ZaposlenikId;
                    break;
                }
            }

            var novost = await _novosti.GetById<Novosti>(Novost.NovostId);
            var insert = new NovostiInsertRequest()
            {
                Naslov = Novost.Naslov,
                Sadrzaj = Novost.Sadrzaj,
                DatumVrijeme = Novost.DatumVrijeme,
                ZaposlenikId = zaposlenikId,
                Slika = this.Slika,
            };
            if (novost.PutovanjeId.HasValue)
            {
                if (PutovanjeSelected == null)
                { var put = await _putovanja.GetById<Putovanja>(novost.PutovanjeId);
                    PutovanjeSelected = put;
                    insert.PutovanjeId = PutovanjeSelected.PutovanjaId;
                  }

            }

            
            await _novosti.Update<Novosti>(Novost.NovostId,insert);

         
        }


    }
}
