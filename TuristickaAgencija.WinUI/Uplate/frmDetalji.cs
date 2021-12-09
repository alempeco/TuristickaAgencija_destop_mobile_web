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

namespace TuristickaAgencija.WinUI.Uplate
{
    public partial class frmDetalji : Form
    {
        APIService _rezervacije = new APIService("Rezervacije");
        APIService _korisnici = new APIService("PutniciKorisnici");
        APIService _uplate = new APIService("Uplate");
        private int? _id = null;
        public frmDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmDetalji_Load(object sender, EventArgs e)
        {
            await LoadRezervacije();
            if (_id.HasValue)
            {
                var entity = await _uplate.GetById<Model.Uplate>(int.Parse(_id.ToString()));
                txtIznos.Text = entity.Iznos.ToString();
                var r = await _rezervacije.GetById<Model.Rezervacije>(entity.RezervacijaId);
                dateTimePicker1.Value = entity.DatumUplate;
                cmbRezervacije.SelectedIndex = cmbRezervacije.FindStringExact(r.RezervacijaPodaci);
            }

        }
        private async Task LoadRezervacije()
        {
            var result = await _rezervacije.Get<List<Model.Rezervacije>>(null);
            cmbRezervacije.DataSource = result;
            cmbRezervacije.DisplayMember = "RezervacijaPodaci";
            cmbRezervacije.ValueMember = "RezervacijaId";
        }

        UplateInsertRequest request = new UplateInsertRequest();
        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            request.DatumUplate = dateTimePicker1.Value;
            request.Iznos = float.Parse(txtIznos.Text);
            request.RezervacijaId = (int)cmbRezervacije.SelectedValue;
            if (_id.HasValue)
            {
                await _uplate.Update<Model.Uplate>(_id, request);
            }
            else
            {
                await _uplate.Insert<Model.Uplate>(request);
            }
            MessageBox.Show("Operacija uspješna");
            this.Close();
        }

        private void txtIznos_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIznos.Text))
            {
                errorProvider1.SetError(txtIznos, "Ovo polje je obavezno.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtIznos.Text, @"[0-9]+"))
            {
                errorProvider1.SetError(txtIznos, "");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIznos, null);
            }

        }

        private void frmDetalji_FormClosing(object sender, FormClosingEventArgs e)
        {
            errorProvider1.Clear();
            e.Cancel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnlinePay.frmOnlinePay frm = new OnlinePay.frmOnlinePay();

            frm.Show();
        }

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}
    }
}
