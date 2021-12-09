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

namespace TuristickaAgencija.WinUI.Smjestaj
{

    public partial class frmSmjestaj : Form
    {
        APIService _gradovi = new APIService("Gradovi");
        APIService _smjestaj = new APIService("Smjestaj");

        public frmSmjestaj()
        {
            InitializeComponent();
        }
        private async void frmSmjestaj_Load(object sender, EventArgs e)
        {
            await LoadGradovi();
            await LoadSmjestaj();
        }

        private async Task LoadGradovi()
        {

            var result = await _gradovi.Get<List<Model.Gradovi>>(null);
            result.Insert(0, new Model.Gradovi());
            cbGradovi.DataSource = result;
            cbGradovi.DisplayMember = "NazivGrada";
            cbGradovi.ValueMember = "GradId";
        }

        private async Task LoadSmjestaj()
        {

            var result = await _smjestaj.Get<List<Model.Smjestaj>>(null);
            dgvSmjestaj.AutoGenerateColumns = false;
            dgvSmjestaj.DataSource = result;

        }

        private async void btnTrazi_MouseClick(object sender, MouseEventArgs e)
        {
            var gradid = (int)cbGradovi.SelectedValue;
            SmjestajSearchRequest search = new SmjestajSearchRequest();

            if (int.TryParse(gradid.ToString(), out int _gradid))
            {
                search.GradId = _gradid;
            }
            if ((int)cbGradovi.SelectedValue == 0)
            {
                search = null;
            }
            var result = await _smjestaj.Get<List<Model.Smjestaj>>(search);
            dgvSmjestaj.AutoGenerateColumns = false;

            dgvSmjestaj.DataSource = result;

        }

        private void btnDodaj_MouseClick(object sender, MouseEventArgs e)
        {
            frmDetalji frm = new frmDetalji();
            frm.Show();
        }
     

        private void dgvSmjestaj_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvSmjestaj.SelectedRows[0].Cells[0].Value;

            frmDetalji frm = new frmDetalji(int.Parse(id.ToString()));

            frm.Show();
        }

       
    }
}
