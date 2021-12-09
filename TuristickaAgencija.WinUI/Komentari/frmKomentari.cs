using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Requests;

namespace TuristickaAgencija.WinUI.Komentari
{
    public partial class frmKomentari : Form
    {
        public frmKomentari()
        {
            InitializeComponent();
        }

        APIService _komentari = new APIService("Komentari");
        APIService _putovanja = new APIService("Putovanja");
        APIService _putovanjaOcjene = new APIService("OcjenePutovanja");
        APIService _ocjene = new APIService("Ocjene");

        private async void frmKomentari_Load(object sender, EventArgs e)
        {
            await LoadPutovanja();
        }

        private async Task LoadPutovanja()
        {
            var result = await _putovanja.Get<List<Model.Putovanja>>(null);
            result.Insert(0, new Model.Putovanja());
            cmbPutovanja.DataSource = result;

            cmbPutovanja.DisplayMember = "Putovanje";
            cmbPutovanja.ValueMember = "PutovanjaId";
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            KomentariSearchRequest search = null;

            OcjenePutovanjaSearchRequest searchOcjene = null;

            if (cmbPutovanja.SelectedIndex > 0)
            {
                search = new KomentariSearchRequest()
                {
                    PutovanjeId = int.Parse(cmbPutovanja.SelectedValue.ToString())

                };
                searchOcjene = new OcjenePutovanjaSearchRequest
                {
                    PutovanjeId = int.Parse(cmbPutovanja.SelectedValue.ToString())
                };
            }


            var list = await _komentari.Get<List<Model.Komentari>>(search);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;
            double temp = 0;
            List<OcjenePutovanja> listOcjene = await _putovanjaOcjene.Get<List<OcjenePutovanja>>(searchOcjene);
            if (listOcjene.Count == 0)
            {
                txtOcjena.Text = 0.ToString();
            }
            else
            {


                foreach (var i in listOcjene)
                {
                    var ocjena = await _ocjene.GetById<Ocjene>(i.OcjenaId);
                    temp += ocjena.VrijednostBrojcano;
                }
                var o = temp / listOcjene.Count;
                txtOcjena.Text = o.ToString();
            }
        }
    }
}
