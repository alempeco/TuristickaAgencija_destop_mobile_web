using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuristickaAgencija.Model.Requests;

namespace TuristickaAgencija.WinUI.Putovanja
{
    public partial class frmNovoPutovanje : Form
    {
        APIService _vrstaPutovanja = new APIService("VrstaPutovanja");
        APIService _gradovi = new APIService("Gradovi");
        APIService _prevoz = new APIService("Prevoz");

        APIService _putovanja = new APIService("Putovanja");
        APIService _service = new APIService("Zaposlenici");
        private int? _id = null;

        public frmNovoPutovanje(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmNovoPutovanje_Load(object sender, EventArgs e)
        {
            await LoadVrstaPutovanja();
            await LoadGradovi();
            await LoadPrevoz();
            if (_id.HasValue) //update
            {
                var putovanje = await _putovanja.GetById<Model.Putovanja>(_id);
                txtNaziv.Text = putovanje.Naziv;
                txtOpis.Text = putovanje.Opis;
                var vrstaputovanja = await _vrstaPutovanja.GetById<Model.VrstaPutovanja>(putovanje.VrstaPutovanjaId);
                cmbVrstaPutovanja.SelectedIndex = cmbVrstaPutovanja.FindStringExact(vrstaputovanja.Oznaka);
                if (putovanje.Slika.Length > 0)
                {
                    pictureBox1.Image = BytesToImage(putovanje.Slika);
                }
                if (putovanje.GradId.HasValue)
                {
                    var grad = await _gradovi.GetById<Model.Gradovi>(putovanje.GradId);
                    cmbGrad.SelectedIndex = cmbGrad.FindStringExact(grad.NazivGrada);
                }
                if (putovanje.PrevozId.HasValue)
                {
                    var prevoz = await _prevoz.GetById<Model.Prevoz>(putovanje.PrevozId);
                    cmbPrevoz.SelectedIndex = cmbPrevoz.FindStringExact(prevoz.Firma+prevoz.TipPrevoza);
                }

            }
        }


        private async Task LoadPrevoz()
        {
            var result = await _prevoz.Get<List<Model.Prevoz>>(null);
            cmbPrevoz.DataSource = result;
            cmbPrevoz.DisplayMember = "PrevozPodaci";
            cmbPrevoz.ValueMember = "PrevozId";
        }
        private async Task LoadGradovi()
        {
            var result = await _gradovi.Get<List<Model.Gradovi>>(null);
            cmbGrad.DataSource = result;
            cmbGrad.DisplayMember = "NazivGrada";
            cmbGrad.ValueMember = "GradId";
        }
        private async Task LoadVrstaPutovanja()
        {
            var result = await _vrstaPutovanja.Get<List<Model.VrstaPutovanja>>(null);
            cmbVrstaPutovanja.DataSource = result;
            cmbVrstaPutovanja.DisplayMember = "Oznaka";
            cmbVrstaPutovanja.ValueMember = "VrstaPutovanjaId";
        }
        ImageConverter imageConverter = new ImageConverter();
        PutovanjaInsertRequest request = new PutovanjaInsertRequest();
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
        private async void btnSpremi_MouseClick(object sender, MouseEventArgs e)
        {
            var vrstaid = cmbVrstaPutovanja.SelectedValue;

            if (int.TryParse(vrstaid.ToString(), out int _vrstaid))
            {
                request.VrstaPutovanjaId = _vrstaid;
            }
            var gradid = cmbGrad.SelectedValue;
            if (int.TryParse(gradid.ToString(), out int _gradid))
            {
                request.GradId = _gradid;
            }

            var prevozid = cmbPrevoz.SelectedValue;
            if (int.TryParse(prevozid.ToString(), out int _prevozid))
            {
                request.PrevozId = _prevozid;
            }

            request.Naziv = txtNaziv.Text;
            request.Opis = txtOpis.Text;
            var zaposlenik = APIService.KorisnickoIme;

            List<Model.Zaposlenici> zapos = await _service.Get<List<Model.Zaposlenici>>(null);
            foreach (var i in zapos)
            {
                if (i.KorisnickoIme == zaposlenik)
                {
                    request.ZaposlenikId = i.ZaposlenikId;
                    break;
                }
            }

            request.Slika = (System.Byte[])imageConverter.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));

            if (!_id.HasValue)
            {
                await _putovanja.Insert<Model.Putovanja>(request);
            }
            else
            {
                await _putovanja.Update<Model.Putovanja>(_id, request);
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

        private void frmNovoPutovanje_FormClosing(object sender, FormClosingEventArgs e)
        {
            errorProvider1.Clear();
            e.Cancel = false;
        }
    }
}
