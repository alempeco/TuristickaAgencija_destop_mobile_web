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

namespace TuristickaAgencija.WinUI.Firme
{
    public partial class frmDetalji : Form
    {
        private int? _id = null;
        APIService _apiService = new APIService("firme");
        public frmDetalji(int? ID = null)
        {
            InitializeComponent();
            _id = ID;
        }


        private async void frmDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var grad = await _apiService.GetById<Model.Firme>(_id);
                txtNaziv.Text = grad.NazivFirme;
                

            }
        }

        private async void btnSnimi_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.ValidateChildren())
            {
                FirmeInsertRequest request = new FirmeInsertRequest()
                {
                    NazivFirme = txtNaziv.Text,
                    
                };
                if (_id.HasValue)
                {
                    await _apiService.Update<Model.Firme>(_id, request);

                }
                else
                {
                    await _apiService.Insert<Model.Firme>(request);
                }
                MessageBox.Show("Operacija uspješna!");
                this.Close();
            }

        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);

            }
        }

     

        private void frmDetalji_FormClosing(object sender, FormClosingEventArgs e)
        {
            errorProvider1.Clear();
            e.Cancel = false;
        }
    }
}
