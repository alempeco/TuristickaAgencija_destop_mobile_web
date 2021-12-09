using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuristickaAgencija.WinUI
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("Zaposlenici");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            APIService.KorisnickoIme = txtUsername.Text;
            APIService.Lozinka = txtPassword.Text;
            try
            {
                await _service.Get<dynamic>(null);
                TuristickaAgencija.Model.Zaposlenici korisnik = null;
                List<TuristickaAgencija.Model.Zaposlenici> lista = await _service.Get<List<TuristickaAgencija.Model.Zaposlenici>>(null);
                korisnik = lista.FirstOrDefault(x => x.KorisnickoIme == APIService.KorisnickoIme);
                if (korisnik != null)
                {
                    frmIndex frm = new frmIndex();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nemate Pravo Pristupa!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Authentikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Niste autentificirani!", "Authentikacija", MessageBoxButtons.OK);
                Application.Restart();
            }

        }


    }
}
