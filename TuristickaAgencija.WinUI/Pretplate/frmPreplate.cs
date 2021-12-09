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

namespace TuristickaAgencija.WinUI.Pretplate
{
    public partial class frmPreplate : Form
    {
        public frmPreplate()
        {
            InitializeComponent();
        }

        APIService _vrsta = new APIService("VrstaPutovanja");
        APIService _pretplate = new APIService("Pretplate");

        private async void frmPreplate_Load(object sender, EventArgs e)
        {
            await LoadVrstePutovanja();
        }

        private async Task LoadVrstePutovanja()
        {
            var result = await _vrsta.Get<List<Model.VrstaPutovanja>>(null);

            cmbVrsta.DataSource = result;
            cmbVrsta.DisplayMember = "Oznaka";
            cmbVrsta.ValueMember = "VrstaPutovanjaId";
        }

        private async void btnTraži_Click(object sender, EventArgs e)
        {
            PretplateSearchRequest search = null;
            if (cmbVrsta.SelectedIndex > 0)
            {
                search = new PretplateSearchRequest()
                {
                    VrstaPutovanjaId = int.Parse(cmbVrsta.SelectedValue.ToString())
                };
            }
            var list = await _pretplate.Get<List<Model.Pretplate>>(search);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;

            if (list.Count == 0)
            {
                txtBroj.Text = 0.ToString();
            }
            else
                txtBroj.Text = list.Count.ToString();
        }
    }
}
