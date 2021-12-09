using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuristickaAgencija.Model.Requests;

namespace TuristickaAgencija.WinUI.Vodici
{
    public partial class frmDetalji : Form
    {
        APIService _vodici = new APIService("Vodici");
        private int? _id = null;
        public frmDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }
        VodicInsertRequest request = new VodicInsertRequest();
        ImageConverter imageConverter = new ImageConverter();


        private async void frmDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {

                var vodic = await _vodici.GetById<Model.Vodici>(_id);
                txtIme.Text = vodic.Ime;
                txtPrezime.Text = vodic.Prezime;
                txtJMBG.Text = vodic.Jmbg;
                txtTelefon.Text = vodic.Kontakt;

                if (vodic.Slika.Length > 0)
                {
                    pictureBox1.Image = BytesToImage(vodic.Slika);
                }

            }
        }
        public Image BytesToImage(byte[] arr)
        {

            MemoryStream ms = new MemoryStream(arr);
            return Image.FromStream(ms);
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {

            request.Ime = txtIme.Text;
            request.Prezime = txtPrezime.Text;
            request.Zauzet = false;
            request.Kontakt = txtTelefon.Text;
            request.Jmbg = txtJMBG.Text;
            request.Slika = (System.Byte[])imageConverter.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));


            if (!_id.HasValue)
            {
                await _vodici.Insert<Model.Vodici>(request);
            }
            else
            {
                await _vodici.Update<Model.Vodici>(_id, request);
            }
            if (this.ValidateChildren())
            {
                MessageBox.Show("Operacija uspješna!");
                this.Close();
            }
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Slika = file;
                txtSlika.Text = fileName;
                Image image = Image.FromFile(fileName);
                pictureBox1.Image = image;
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider1.SetError(txtIme, "Ovo polje je obavezno.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtIme.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider1.SetError(txtIme, "Ime smije da sadrži samo slova");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIme, null);

            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider1.SetError(txtPrezime, "Ovo polje je obavezno.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtPrezime.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider1.SetError(txtPrezime, "Prezime mora da sadrži samo slova!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPrezime, null);

            }
        }
        private void txtJMBG_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJMBG.Text))
            {
                errorProvider1.SetError(txtJMBG, "Ovo polje je obavezno.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtJMBG.Text, @"[0-9]{13}"))
            {
                errorProvider1.SetError(txtJMBG, "JMBG sadrži 13 brojeva!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtJMBG, null);

            }
        }


        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                errorProvider1.SetError(txtTelefon, "Ovo polje je obavezno.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtTelefon.Text, @"^[+]{1}\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{3}"))
            {
                errorProvider1.SetError(txtTelefon, "Format: +123 45 678 910");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTelefon, null);

            }
        }

        private void frmDetalji_FormClosing(object sender, FormClosingEventArgs e)
        {
            errorProvider1.Clear();
            e.Cancel = false;
        }


    }
}
