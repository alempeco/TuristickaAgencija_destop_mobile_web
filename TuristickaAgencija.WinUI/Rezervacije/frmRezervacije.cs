using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuristickaAgencija.WinUI.Rezervacije
{
    public partial class frmRezervacije : Form
    {
        APIService _rezervacije = new APIService("Rezervacije");
        APIService _termini = new APIService("TerminiPutovanja");
        public frmRezervacije()
        {
            InitializeComponent();
        }
        private async void frmRezervacije_Load(object sender, EventArgs e)
        {
            var result = await _rezervacije.Get<List<Model.Rezervacije>>(null);
            dgvRezervacije.AutoGenerateColumns = false;
            dgvRezervacije.DataSource = result;
            ;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDetalji frm = new frmDetalji(null);
            frm.Show();
        }

        private async void dgvRezervacije_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            var id = dgvRezervacije.SelectedRows[0].Cells[0].Value;
            Model.Rezervacije rez = await _rezervacije.GetById<Model.Rezervacije>(int.Parse(id.ToString()));
            var termin = await _termini.GetById<Model.TerminiPutovanja>(rez.TerminPutovanjaId);


            DialogResult dialogResult = MessageBox.Show("Da li želite otkazati rezervaciju?", "Otkazivanje", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if ((termin.DatumPolaska - DateTime.Now).TotalDays > 3)
                {
                    await _rezervacije.Delete<Model.Rezervacije>(id);
                    MessageBox.Show("Rezervacija otkazana.");
                }
                else
                {
                    MessageBox.Show("Nije moguće otkazati.");
                }
            }


        }

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}
    }
}
