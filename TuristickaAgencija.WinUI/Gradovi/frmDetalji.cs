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

namespace TuristickaAgencija.WinUI.Gradovi
{
    public partial class frmDetalji : Form
    {
        private int? _id = null;
        APIService _drzave = new APIService("Drzave");
        APIService _gradovi = new APIService("Gradovi");
        public frmDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmDetalji_Load(object sender, EventArgs e)
        {
            await LoadDrzave();
            if (_id.HasValue) //update
            {
                var gradovi = await _gradovi.GetById<Model.Gradovi>(_id);
                txtNaziv.Text = gradovi.NazivGrada;

                var drzave = await _drzave.GetById<Model.Drzave>(gradovi.DrzaveId);
                cmbDrzave.SelectedIndex = cmbDrzave.FindStringExact(gradovi.Drzave);


            }
        }
        private async Task LoadDrzave()
        {

            var result = await _drzave.Get<List<Model.Drzave>>(null);

            cmbDrzave.DataSource = result;
            cmbDrzave.DisplayMember = "NazivDrzave";
            cmbDrzave.ValueMember = "DrzaveId";
        }
        GradoviInsertRequest request = new GradoviInsertRequest();
        private async void btnSnimi_MouseClick(object sender, MouseEventArgs e)
        {
            var drzavaid = cmbDrzave.SelectedValue;


            request.NazivGrada = txtNaziv.Text;
            
            request.DrzaveId = int.Parse(drzavaid.ToString());


            if (!_id.HasValue)
            {
                await _gradovi.Insert<Model.Gradovi>(request);
            }
            else
            {
                await _gradovi.Update<Model.Gradovi>(_id, request);
            }
            if (this.ValidateChildren())
            {
                MessageBox.Show("Operacija uspješna!");
                this.Close();
            }
        }

        private void frmDetalji_FormClosing(object sender, FormClosingEventArgs e)
        {
            errorProvider1.Clear();
            e.Cancel = false;
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, "Ovo polje je obavezno.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }
    }
}
