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

namespace TuristickaAgencija.WinUI.Termini
{
    public partial class frmTermini : Form
    {
        APIService _termini = new APIService("TerminiPutovanja");
        APIService _putovanja = new APIService("Putovanja");
        private int? _id = null;
        public frmTermini(int? id = null)
        {
            InitializeComponent();
            _id = id;
            this.dgvTermini.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTermini_DataError);

        }

        private async void frmTermini_Load(object sender, EventArgs e)
        {
            await LoadPutovanja();
            var result = await _termini.Get<List<Model.TerminiPutovanja>>(null);
            dgvTermini.AutoGenerateColumns = false;
            dgvTermini.DataSource = result;

        }
        private async Task LoadPutovanja()
        {
            var result = await _putovanja.Get<List<Model.Putovanja>>(null);
            result.Insert(0, new Model.Putovanja());
            cmbPutovanja.DataSource = result;

            cmbPutovanja.DisplayMember = "Putovanje";
            cmbPutovanja.ValueMember = "PutovanjaId";
        }

        private void btnNoviTermin_MouseClick(object sender, MouseEventArgs e)
        {
            frmDetalji frm = new frmDetalji();
            frm.Show();
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {

            var search = new TerminiSearchRequest();
            if ((int?)cmbPutovanja.SelectedValue > 0)
            {
                search.PutovanjeId = (int?)cmbPutovanja.SelectedValue;
            }
            else
            {
                search = null;
            }
            var result = await _termini.Get<List<Model.TerminiPutovanja>>(search);
            dgvTermini.AutoGenerateColumns = false;
            dgvTermini.DataSource = result;


        }

        private void dgvTermini_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvTermini.SelectedRows[0].Cells[0].Value;

            frmDetalji frm = new frmDetalji(int.Parse(id.ToString()));

            frm.Show();
        }

        private void dgvTermini_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
