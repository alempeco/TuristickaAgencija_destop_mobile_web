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

namespace TuristickaAgencija.WinUI.PutniciKorisnici
{
    public partial class frmPutniciKorisnici : Form
    {
        APIService _korisnik = new APIService("PutniciKorisnici");

        public frmPutniciKorisnici()
        {
            InitializeComponent();
        }

        private async void frmPutniciKorisnici_Load(object sender, EventArgs e)
        {
            var result = await _korisnik.Get<List<Model.PutniciKorisnici>>(null);
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = result;
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            var search = new PutniciKorisniciSearchRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text
            };
            var list=await _korisnik.Get<List<Model.PutniciKorisnici>>(search);
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = list;

        }
    }
}
