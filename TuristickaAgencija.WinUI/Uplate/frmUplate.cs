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

namespace TuristickaAgencija.WinUI.Uplate
{
    public partial class frmUplate : Form
    {
        APIService _rezervacije = new APIService("Rezervacije");
        APIService _korisnici = new APIService("PutniciKorisnici");
        APIService _uplate = new APIService("Uplate");
        public frmUplate()
        {
            InitializeComponent();
        }

        private async Task LoadRezervacije()
        {
            var result = await _rezervacije.Get<List<Model.Rezervacije>>(null);
            result.Insert(0, new Model.Rezervacije());
            cmbRezervacije.DataSource = result;
            cmbRezervacije.DisplayMember = "RezervacijaPodaci";
            cmbRezervacije.ValueMember = "RezervacijaId";
        }


        private async void frmUplate_Load(object sender, EventArgs e)
        {
            await LoadRezervacije();

            var result = await _uplate.Get<List<Model.Uplate>>(null);
            dgvUplate.AutoGenerateColumns = false;
            dgvUplate.DataSource = result;
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {

            var rezid = (int)cmbRezervacije.SelectedValue;
            var search = new UplateSearchRequest();


            if (int.TryParse(rezid.ToString(), out int _rezid))
            {
                search.RezervacijaId = _rezid;

            }
            if ((int)cmbRezervacije.SelectedValue == 0)
            {
                search = null;
            }
            var result = await _uplate.Get<List<Model.Uplate>>(search);
            dgvUplate.AutoGenerateColumns = false;

            dgvUplate.DataSource = result;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDetalji frm = new frmDetalji();
            frm.Show();
        }

        private void dgvUplate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvUplate.SelectedRows[0].Cells[0].Value;
            frmDetalji frm = new frmDetalji(int.Parse(id.ToString()));
            frm.Show();

        }
    }
}
