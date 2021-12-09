using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuristickaAgencija.Model.Requests;

namespace TuristickaAgencija.WinUI.Firme
{
    public partial class frmFirme : Form
    {
        private readonly APIService _apiService = new APIService("Firme");
        public frmFirme()
        {
            InitializeComponent();
        }

        private void dgvFirme_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvFirme.SelectedRows[0].Cells[0].Value;

            frmDetalji detalji = new frmDetalji(int.Parse(id.ToString()));

            detalji.Show();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDetalji frm = new frmDetalji();
            frm.Show();
        }
        private async void txtPretragaNaziv_TextChanged(object sender, EventArgs e)
        {
            var search = new FirmeSearchRequest()
            {
                NazivFirme = txtPretragaNaziv.Text
            };

            var result = await _apiService.Get<List<Model.Firme>>(search);
            dgvFirme.DataSource = result;
        }
        private async void frmFirme_Load(object sender, EventArgs e)
        {
            var result = await _apiService.Get<List<Model.Firme>>(null);
            dgvFirme.DataSource = result;
        }

       
    }
}
