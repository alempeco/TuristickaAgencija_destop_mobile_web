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

namespace TuristickaAgencija.WinUI.Putovanja
{
    public partial class frmPutovanja : Form
    {
        APIService _putovanja = new APIService("Putovanja");
        APIService _vrstaputovanja = new APIService("VrstaPutovanja");
        public frmPutovanja()
        {
            InitializeComponent();
            this.dgvPutovanja.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPutovanja_DataError);
        }


        private async Task LoadPutovanja()
        {
            var result = await _putovanja.Get<List<Model.Putovanja>>(null);
            dgvPutovanja.AutoGenerateColumns = false;

            dgvPutovanja.DataSource = result;
        }

        private async Task LoadVrstaPutovanja()
        {

            var result = await _vrstaputovanja.Get<List<Model.VrstaPutovanja>>(null);
            result.Insert(0, new Model.VrstaPutovanja());
            cmbPretraga.DataSource = result;
            cmbPretraga.DisplayMember = "Oznaka";
            cmbPretraga.ValueMember = "VrstaPutovanjaId";
        }

        private async void frmPutovanja_Load(object sender, EventArgs e)
        {
            await LoadPutovanja();
            await LoadVrstaPutovanja();
        }

        private void btnDodaj_MouseClick(object sender, MouseEventArgs e)
        {
            frmNovoPutovanje frm = new frmNovoPutovanje(null);
            frm.Show();

        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            var vrstaid = (int)cmbPretraga.SelectedValue;
            PutovanjaSearchRequest search = new PutovanjaSearchRequest();

            if (int.TryParse(vrstaid.ToString(), out int _vrstaid))
            {
                search.VrstaPutovanjaId = _vrstaid;
            }
            if ((int)cmbPretraga.SelectedValue == 0)
            {
                search = null;
            }
            var result = await _putovanja.Get<List<Model.Putovanja>>(search);
            dgvPutovanja.AutoGenerateColumns = false;

            dgvPutovanja.DataSource = result;

        }





        private void dgvPutovanja_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvPutovanja.SelectedRows[0].Cells[0].Value;

            frmNovoPutovanje frm = new frmNovoPutovanje(int.Parse(id.ToString()));

            frm.Show();
        }

        private void dgvPutovanja_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

    }
}
