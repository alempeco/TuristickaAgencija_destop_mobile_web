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

namespace TuristickaAgencija.WinUI.OnlinePay
{
    public partial class frmOnlinePay : Form
    {
        private readonly APIService _apiService = new APIService("OnlinePay");

        public frmOnlinePay()
        {
            InitializeComponent();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dataGridView1.SelectedRows[0].Cells[0].Value;

            frmDetalji detalji = new frmDetalji(int.Parse(id.ToString()));

            detalji.Show();
        }

        private async void txtPretragaNaziv_TextChanged(object sender, EventArgs e)
        {
            var search = new OnlinePaySearchRequest()
            {
                KorisnickoIme = txtPretragaNaziv.Text,

            };

            var result = await _apiService.Get<List<Model.OnlinePay>>(search);
            dataGridView1.DataSource = result;
        }

        private async void frmOnlinePay_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            var result = await _apiService.Get<List<Model.OnlinePay>>(null);
            dataGridView1.DataSource = result;
        }
    }
}
