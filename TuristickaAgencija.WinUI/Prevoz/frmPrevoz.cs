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

namespace TuristickaAgencija.WinUI.Prevoz
{
    public partial class frmPrevoz : Form
    {
        APIService _firme = new APIService("Firme");
        APIService _prevoz = new APIService("Prevoz");
        public frmPrevoz()
        {
            InitializeComponent();
        }

        private async void frmPrevoz_Load(object sender, EventArgs e)
        {
            await LoadFirme();
            await LoadPrevoz();
        }
        private async Task LoadFirme()
        {

            var result = await _firme.Get<List<Model.Firme>>(null);
            result.Insert(0, new Model.Firme());
            cbFirme.DataSource = result;
            cbFirme.DisplayMember = "NazivFirme";
            cbFirme.ValueMember = "FirmaId";
        }
        private async Task LoadPrevoz()
        {

            var result = await _prevoz.Get<List<Model.Prevoz>>(null);
            dgvPrevoz.AutoGenerateColumns = false;
            dgvPrevoz.DataSource = result;

        }
        private async void btnTrazi_MouseClick(object sender, MouseEventArgs e)
        {
            var firmaid = (int)cbFirme.SelectedValue;
            PrevozSearchRequest search = new PrevozSearchRequest();

            if (int.TryParse(firmaid.ToString(), out int _firmaid))
            {
                search.FirmaId = _firmaid;
            }
            if ((int)cbFirme.SelectedValue == 0)
            {
                search = null;
            }
            var result = await _prevoz.Get<List<Model.Prevoz>>(search);
            dgvPrevoz.AutoGenerateColumns = false;

            dgvPrevoz.DataSource = result;
        }

        private void btnDodaj_MouseClick(object sender, MouseEventArgs e)
        {
            frmDetalji frm = new frmDetalji();
            frm.Show();
        }

        private void dgvPrevoz_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvPrevoz.SelectedRows[0].Cells[0].Value;

            frmDetalji frm = new frmDetalji(int.Parse(id.ToString()));

            frm.Show();
        }

        //private void cbFirme_MouseClick(object sender, MouseEventArgs e)
        //{

        //}
    }
}
