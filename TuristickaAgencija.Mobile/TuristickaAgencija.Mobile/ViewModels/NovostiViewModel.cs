using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;
using Xamarin.Forms;

namespace TuristickaAgencija.Mobile.ViewModels
{
    public class NovostiViewModel
    {
        public NovostiViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }
        private readonly APIService _service = new APIService("Novosti");
        public ObservableCollection<Novosti> NovostiList { get; set; } = new ObservableCollection<Novosti>();


        public ICommand InitCommand { get; set; }


        public async Task Init()
        {
            var list = await _service.Get<IEnumerable<Novosti>>(null);
            NovostiList.Clear();
            foreach (var novost in list)
            {
                NovostiList.Add(novost);
            }
        }
    }
}
