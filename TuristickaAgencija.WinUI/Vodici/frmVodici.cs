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

namespace TuristickaAgencija.WinUI.Vodici
{
    public partial class frmVodici : Form
    {
        APIService _vodici = new APIService("Vodici");

        public frmVodici()
        {
            InitializeComponent();
            this.dgvVodici.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvVodici_DataError);

        }


        private async void frmVodici_Load(object sender, EventArgs e)
        {
            var result = await _vodici.Get<List<Model.Vodici>>(null);
            dgvVodici.AutoGenerateColumns = false;
            dgvVodici.DataSource = result;

        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            VodicSearchRequest search = new VodicSearchRequest();

            if (cbZauzet == null)
            {
                search = null;
            }
            else
            {
                search.Zauzet = cbZauzet.Checked;

            }
            var result = await _vodici.Get<List<Model.Vodici>>(search);
            dgvVodici.DataSource = result;

        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            frmDetalji frm = new frmDetalji(null);

            frm.Show();
        }

        private void dgvVodici_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvVodici_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvVodici.SelectedRows[0].Cells[0].Value;

            frmDetalji frm = new frmDetalji(int.Parse(id.ToString()));

            frm.Show();
        }
    }
}
