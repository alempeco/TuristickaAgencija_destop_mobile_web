using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class ZaposlenikUplateInfo : BaseViewModel
    {
        public ZaposlenikUplateInfo()
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
        double _ukupnoUplate = 0;
        public double UkupnoUplate
        {
            get { return _ukupnoUplate; }
            set { SetProperty(ref _ukupnoUplate, value); }
        }


        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            BrojUplata = 0;
            NijePlacenoSuma = 0;
            PlacenoSuma = 0;


            var uplate = await _serviceUplate.Get<List<Uplate>>(null);

            foreach (var i in uplate)
            {
                PlacenoSuma += i.Iznos;
            }

            BrojUplata = uplate.Count;
            APIService _serviceTermini = new APIService("TerminiPutovanja");
            APIService _serviceRezervacije = new APIService("Rezervacije");

            //PotrebanIznos
            var rezervacije = await _serviceRezervacije.Get<List<Rezervacije>>(null);
            double terminiPotrebanIznos = 0;

            foreach (var i in rezervacije)
            {
                var termin = await _serviceTermini.GetById<TerminiPutovanja>(i.TerminPutovanjaId);

                terminiPotrebanIznos += (double)termin.Cijena;
            }
            UkupnoUplate = terminiPotrebanIznos;

            NijePlacenoSuma = terminiPotrebanIznos - PlacenoSuma;
            if (NijePlacenoSuma < 0)
            {
                NijePlacenoSuma = 0;
            }
        }
    }
}