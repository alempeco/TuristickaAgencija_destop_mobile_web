using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuristickaAgencija.Model.Requests;

namespace TuristickaAgencija.WinUI.Prevoz
{
    public partial class frmDetalji : Form
    {
        private int? _id = null;
        APIService _firme = new APIService("Firme");
        APIService _tipPrevoza = new APIService("TipPrevoza");

        APIService _prevoz = new APIService("Prevoz");
        public frmDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmDetalji_Load(object sender, EventArgs e)
        {
            await LoadFirme();
            await LoadTipPrevoza();
            if (_id.HasValue) //update
            {
                var prevoz = await _prevoz.GetById<Model.Prevoz>(_id);
               
                txtCijena.Text = prevoz.CijenaPoMjestu.ToString();
                txtBrojMjesta.Text = prevoz.BrojMjesta.ToString();
               
                var firme = await _firme.GetById<Model.Firme>(prevoz.FirmaId);
                cmbFirma.SelectedIndex = cmbFirma.FindStringExact(prevoz.Firma);


                var tipprevoza = await _tipPrevoza.GetById<Model.TipPrevoza>(prevoz.TipPrevozaId);
                cmbTipPrevoza.SelectedIndex = cmbTipPrevoza.FindStringExact(prevoz.TipPrevoza);

            }
        }
        private async Task LoadFirme()
        {

            var result = await _firme.Get<List<Model.Firme>>(null);

            cmbFirma.DataSource = result;
            cmbFirma.DisplayMember = "NazivFirme";
            cmbFirma.ValueMember = "FirmaId";
        }

        private async Task LoadTipPrevoza()
        {

            var result = await _tipPrevoza.Get<List<Model.TipPrevoza>>(null);

            cmbTipPrevoza.DataSource = result;
            cmbTipPrevoza.DisplayMember = "NazivTipa";
            cmbTipPrevoza.ValueMember = "TipPrevozaId";
        }
        PrevozInsertRequest request = new PrevozInsertRequest();

        private async void btnSnimi_MouseClick(object sender, MouseEventArgs e)
        {
            
            var firmaid = cmbFirma.SelectedValue;
            var tipprevozaid = cmbTipPrevoza.SelectedValue;

           
            request.CijenaPoMjestu = (float.Parse(txtCijena.Text));
            request.BrojMjesta = (int.Parse(txtBrojMjesta.Text));
           
            request.FirmaId = int.Parse(firmaid.ToString());
            request.TipPrevozaId = int.Parse(tipprevozaid.ToString());



            if (!_id.HasValue)
            {
                await _prevoz.Insert<Model.Prevoz>(request);
            }
            else
            {
                await _prevoz.Update<Model.Prevoz>(_id, request);
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

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijena.Text))
            {
                errorProvider1.SetError(txtCijena, "Ovo polje je obavezno.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtCijena.Text, @"[0-9]+"))
            {
                errorProvider1.SetError(txtCijena, "Samo brojevi");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCijena, null);

            }
        }

        private void txtBrojMjesta_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrojMjesta.Text))
            {
                errorProvider1.SetError(txtBrojMjesta, "Ovo polje je obavezno.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtBrojMjesta.Text, @"[0-9]+"))
            {
                errorProvider1.SetError(txtBrojMjesta, "Samo brojevi");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBrojMjesta, null);

            }
        }

       

       
    }
}
