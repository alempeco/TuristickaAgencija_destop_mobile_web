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

namespace TuristickaAgencija.WinUI.Smjestaj
{
    public partial class frmDetalji : Form
    {
        private int? _id = null;
        APIService _gradovi = new APIService("Gradovi");
        APIService _smjestaj = new APIService("Smjestaj");
        public frmDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmDetalji_Load(object sender, EventArgs e)
        {
            await LoadGradovi();
            if (_id.HasValue) //update
            {
                var smjestaj = await _smjestaj.GetById<Model.Smjestaj>(_id);
                txtNaziv.Text = smjestaj.Naziv;
                txtTipSobe.Text = smjestaj.TipSobe;
                txtOpis.Text = smjestaj.Opis;

                txtCijena.Text = smjestaj.CijenaNoc.ToString();
                var gradovi = await _gradovi.GetById<Model.Gradovi>(smjestaj.GradId);
                cmbGrad.SelectedIndex = cmbGrad.FindStringExact(gradovi.NazivGrada);
                if (smjestaj.Slika.Length > 0)
                {
                    pictureBox1.Image = BytesToImage(smjestaj.Slika);
                }

            }

        }
        private async Task LoadGradovi()
        {

            var result = await _gradovi.Get<List<Model.Gradovi>>(null);

            cmbGrad.DataSource = result;
            cmbGrad.DisplayMember = "NazivGrada";
            cmbGrad.ValueMember = "GradId";
        }
        ImageConverter imageConverter = new ImageConverter();
        SmjestajInsertRequest request = new SmjestajInsertRequest();
        private async void btnSnimi_MouseClick(object sender, MouseEventArgs e)
        {
            var gradid = cmbGrad.SelectedValue;


            request.Naziv = txtNaziv.Text;
            request.Opis = txtOpis.Text;
            request.TipSobe = txtTipSobe.Text;


            request.CijenaNoc = (double.Parse(txtCijena.Text));
            request.GradId = int.Parse(gradid.ToString());
            request.Slika = (System.Byte[])imageConverter.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));


            if (!_id.HasValue)
            {
                await _smjestaj.Insert<TuristickaAgencija.Model.Smjestaj>(request);
            }
            else
            {
                await _smjestaj.Update<TuristickaAgencija.Model.Smjestaj>(_id, request);
            }
            if (this.ValidateChildren())
            {
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

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijena.Text))
            {
                errorProvider1.SetError(txtCijena, Properties.Resources.Validation_Required);
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

        private void frmDetalji_FormClosing(object sender, FormClosingEventArgs e)
        {
            errorProvider1.Clear();
            e.Cancel = false;
        }

        private void txtTipSobe_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipSobe.Text))
            {
                errorProvider1.SetError(txtTipSobe, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTipSobe, null);
            }
        }

        private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                errorProvider1.SetError(txtOpis, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtOpis, null);
            }
        }

        private void btnUcitaj_MouseClick(object sender, MouseEventArgs e)
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
        public Image BytesToImage(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            return Image.FromStream(ms);
        }
    }
}
