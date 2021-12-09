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

namespace TuristickaAgencija.WinUI.Novosti
{
    public partial class frmNovosti : Form
    {
        APIService _putovanja = new APIService("Putovanja");
        APIService _novosti = new APIService("Novosti");
        public frmNovosti()
        {
            InitializeComponent();
            this.dgvNovosti.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvNovosti_DataError);

        }

        private async void frmNovosti_Load(object sender, EventArgs e)
        {
            await LoadPutovanja();
            await LoadNovosti();

        }
        private async Task LoadPutovanja()
        {

            var result = await _putovanja.Get<List<Model.Putovanja>>(null);
            result.Insert(0, new Model.Putovanja());
            cmbPutovanja.DataSource = result;

            cmbPutovanja.ValueMember = "PutovanjaId";
            cmbPutovanja.DisplayMember = "Putovanje";
        }
        private async Task LoadNovosti()
        {
            var result = await _novosti.Get<List<Model.Novosti>>(null);
            dgvNovosti.AutoGenerateColumns = false;
            dgvNovosti.DataSource = result;
        }


        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDetalji frm = new frmDetalji();
            frm.Show();
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            NovostiSearchRequest search = new NovostiSearchRequest();

            if ((int)cmbPutovanja.SelectedValue == 0)
            {
                search = null;
            }
            else
            {
                search.PutovanjeId = (int?)cmbPutovanja.SelectedValue;
            }
            var result = await _novosti.Get<List<Model.Novosti>>(search);
            dgvNovosti.AutoGenerateColumns = false;
            dgvNovosti.DataSource = result;
        }

        private void dgvNovosti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dgvNovosti.SelectedRows[0].Cells[0].Value;

            frmDetalji frm = new frmDetalji(int.Parse(id.ToString()));

            frm.Show();
        }

        private void dgvNovosti_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
