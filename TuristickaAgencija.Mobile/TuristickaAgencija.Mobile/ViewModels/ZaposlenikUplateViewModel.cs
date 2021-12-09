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
    public class ZaposlenikUplateViewModel : BaseViewModel
    {
        public ZaposlenikUplateViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        readonly APIService _serviceUplate = new APIService("Uplate");
        public ObservableCollection<Uplate> ListUplate { get; set; } = new ObservableCollection<Uplate>();
        public ObservableCollection<TerminiPutovanja> ListTermini { get; set; } = new ObservableCollection<TerminiPutovanja>();
        public ICommand InitCommand { get; set; }

        //pretraga po terminu

        bool _terminVisible = false;
        public bool TerminVisible
        {
            get { return _terminVisible; }
            set
            { SetProperty(ref _terminVisible, value); }
        }

        TerminiPutovanja _terminSelected = null;
        public TerminiPutovanja TerminSelected
        {
            get { return _terminSelected; }
            set
            {
                SetProperty(ref _terminSelected, value);
                if (value != null)
                {
                    TerminVisible = true;
                    InitCommand.Execute(null);
                }
            }
        }
        double _uplaceno = 0;
        public double Uplaceno
        {
            get { return _uplaceno; }
            set
            { SetProperty(ref _uplaceno, value); }
        }
        double _nijeUplaceno = 0;
        public double NijeUplaceno
        {
            get { return _nijeUplaceno; }
            set
            { SetProperty(ref _nijeUplaceno, value); }
        }
        public async Task Init()
        {
            APIService _serviceRezervacije = new APIService("Rezervacije");
            APIService _serviceTermini = new APIService("TerminiPutovanja");
            ListUplate.Clear();
            var uplate = await _serviceUplate.Get<List<Uplate>>(null);

            if (TerminSelected != null)
            {

                Uplaceno = 0;
                NijeUplaceno = 0;

                foreach (var i in uplate)
                {
                    var rez = await _serviceRezervacije.GetById<Rezervacije>(i.RezervacijaId);
                    if (rez.TerminPutovanjaId == TerminSelected.TerminPutovanjaId)
                    {
                        ListUplate.Add(i);
                        Uplaceno += i.Iznos;
                    }


                }


                List<Rezervacije> rezervacije = await _serviceRezervacije.Get<List<Rezervacije>>(new RezervacijeSearchRequest
                {
                    TerminId = TerminSelected.TerminPutovanjaId
                });
                NijeUplaceno = (rezervacije.Count * (double)TerminSelected.Cijena) - Uplaceno;
            }
            else
            {
                foreach (var u in uplate)
                {
                    ListUplate.Add(u);
                }
            }



            ListTermini.Clear();
            var termini = await _serviceTermini.Get<List<TerminiPutovanja>>(null);
            foreach (var i in termini)
            {
                ListTermini.Add(i);
            }
        }
    }
}
