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

namespace TuristickaAgencija.WinUI.Termini
{
    public partial class frmDetalji : Form
    {
        APIService _smjestaj = new APIService("Smjestaj");
        APIService _vodici = new APIService("Vodici");

        APIService _termini = new APIService("TerminiPutovanja");
        APIService _putovanja = new APIService("Putovanja");
        private int? _id = null;
        public frmDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        ImageConverter imageConverter = new ImageConverter();

        private async void frmDetalji_Load(object sender, EventArgs e)
        {
            await LoadSmjestaj();
            await LoadPutovanja();
            await LoadVodic();
            if (_id.HasValue)
            {
                var entity = await _termini.GetById<Model.TerminiPutovanja>(_id);
                txtBrojMjesta.Text = entity.BrojMjesta.ToString();
                txtCijena.Text = entity.Cijena.ToString();
                dateTimeDO.Value = (DateTime)entity.DatumPovratka;

                dateTimeOD.Value = (DateTime)entity.DatumPolaska;
                if (entity.Slika.Length > 0)
                {
                    pictureBox1.Image = BytesToImage(entity.Slika);
                }
                if (entity.PutovanjeId > 0)
                {
                    var put = await _putovanja.GetById<Model.Putovanja>(entity.PutovanjeId);
                    cmbPutovanja.SelectedIndex = cmbPutovanja.FindStringExact(put.Putovanje);
                }
                if (entity.SmjestajId > 0)
                {
                    var smjestaj = await _smjestaj.GetById<Model.Smjestaj>(entity.SmjestajId);
                    cmbSmjestaj.SelectedIndex = cmbSmjestaj.FindStringExact(smjestaj.SmjestajPodaci);
                }
                if (entity.VodicId > 0)
                {
                    var vodic = await _vodici.GetById<Model.Vodici>(entity.VodicId);
                    cmbVodic.SelectedIndex = cmbVodic.FindStringExact(vodic.Vodic);
                }
                if (entity.Aktivno == true)
                {
                    cbAktivno.Checked = true;
                }

            }

        }
        private async Task LoadVodic()
        {
          
        var result = await _vodici.Get<List<Model.Vodici>>(null);

            cmbVodic.DataSource = result;
            cmbVodic.DisplayMember = "Vodic";
            cmbVodic.ValueMember = "VodicId";
        }
        private async Task LoadSmjestaj()
        {

            var result = await _smjestaj.Get<List<Model.Smjestaj>>(null);

            cmbSmjestaj.DataSource = result;
            cmbSmjestaj.DisplayMember = "SmjestajPodaci";
            cmbSmjestaj.ValueMember = "SmjestajId";
        }

        private async Task LoadPutovanja()
        {
            var result = await _putovanja.Get<List<Model.Putovanja>>(null);
            //result.Insert(0, new Model.Putovanja());
            cmbPutovanja.DataSource = result;

            cmbPutovanja.DisplayMember = "Putovanje";
            cmbPutovanja.ValueMember = "PutovanjaId";
        }

        TerminiPutovanjaInsertRequest request = new TerminiPutovanjaInsertRequest();
        private async void btnSnimi_Click(object sender, EventArgs e)
        {



            request.BrojMjesta = int.Parse(txtBrojMjesta.Text.ToString());
            request.Cijena = double.Parse(txtCijena.Text.ToString());
            request.PutovanjeId = (int)cmbPutovanja.SelectedValue;
            request.SmjestajId = (int?)cmbSmjestaj.SelectedValue;
            request.VodicId = (int?)cmbVodic.SelectedValue;

            request.DatumPolaska = dateTimeOD.Value;
            request.DatumPovratka = dateTimeDO.Value;
            if (txtSlika.Text.Length > 0)
                request.Slika = (System.Byte[])imageConverter.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));

            if (cbAktivno.Checked == true)
            {
                request.Aktivno = true;
            }
            else
            {
                request.Aktivno = false;
            }
            if (this.ValidateChildren())
            {
                if (!_id.HasValue)
                {
                    await _termini.Insert<Model.TerminiPutovanja>(request);
                }
                else
                {
                    await _termini.Update<Model.TerminiPutovanja>(_id, request);
                }

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
        public Image BytesToImage(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            return Image.FromStream(ms);
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
                errorProvider1.SetError(txtCijena, "");
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
                errorProvider1.SetError(txtBrojMjesta, "");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBrojMjesta, null);
            }
        }




        private void dateTimeDO_Validating(object sender, CancelEventArgs e)
        {
            if (dateTimeOD.Value > dateTimeDO.Value)
            {
                errorProvider1.SetError(dateTimeDO, "Datum povratka mora biti veći od datuma polaska!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(dateTimeDO, null);

            }
        }
        private void frmDetalji_FormClosing(object sender, FormClosingEventArgs e)
        {
            errorProvider1.Clear();
            e.Cancel = false;
        }
    }
}
