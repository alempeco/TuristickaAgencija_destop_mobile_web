using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Requests;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class AktivniTerminiViewModel : BaseViewModel
    {

        public ObservableCollection<TerminiPutovanja> TerminiList { get; set; } = new ObservableCollection<TerminiPutovanja>();
        readonly APIService _service = new APIService("TerminiPutovanja");
        readonly APIService _serviceRezervacije = new APIService("Rezervacije");



        public ICommand InitCommand { get; set; }

        public async Task Init()
        {



            var list = await _service.Get<IEnumerable<TerminiPutovanja>>(new TerminiSearchRequest
            {
                Aktivno = true
            });
            TerminiList.Clear();



            foreach (var i in list)
            {

                if (i.DatumPolaska > DateTime.Now)
                {
                    TerminiList.Add(i);
                }
            }


        }

    }
}
