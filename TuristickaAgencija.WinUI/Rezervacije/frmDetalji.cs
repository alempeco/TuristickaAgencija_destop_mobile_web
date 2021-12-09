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

namespace TuristickaAgencija.WinUI.Rezervacije
{
    public partial class frmDetalji : Form
    {
        APIService _termini = new APIService("TerminiPutovanja");
        APIService _korisnici = new APIService("PutniciKorisnici");
        APIService _rezervacije = new APIService("Rezervacije");
        private int? _id = null;
        public frmDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmDetalji_Load(object sender, EventArgs e)
        {
            await LoadTermini();
            await LoadKorisnici();
            if (_id.HasValue)
            {
                var rezervacija = await _rezervacije.GetById<Model.Rezervacije>(_id);
                var korisnik = await _korisnici.GetById<Model.PutniciKorisnici>(rezervacija.PutnikKorisnikId);
                cmbPutniciKorisnici.SelectedIndex = cmbPutniciKorisnici.FindStringExact(korisnik.KorisnickoIme);
                var termini = await _termini.GetById<Model.TerminiPutovanja>(rezervacija.TerminPutovanjaId);
                cmbTermini.SelectedIndex = cmbTermini.FindStringExact(termini.TerminPutovanjaPodaci);
            }
        }
        private async Task LoadTermini()
        {

            var lista = await _termini.Get<List<Model.TerminiPutovanja>>(new
            TerminiSearchRequest
            {
                Aktivno = true
            });

            var result = new List<Model.TerminiPutovanja>();
            foreach (var i in lista)
            {
                if ((i.DatumPolaska - DateTime.Now).TotalDays > 3)
                {
                    result.Add(i);
                }
            }

            cmbTermini.DataSource = result;
            cmbTermini.DisplayMember = "TerminPutovanjaPodaci";
            cmbTermini.ValueMember = "TerminPutovanjaId";
        }
        private async Task LoadKorisnici()
        {
            var result = await _korisnici.Get<List<Model.PutniciKorisnici>>(null);
            cmbPutniciKorisnici.DataSource = result;
            cmbPutniciKorisnici.DisplayMember = "KorisnickoIme";
            cmbPutniciKorisnici.ValueMember = "PutnikKorisnikId";
        }
        RezervacijeInsertRequest request = new RezervacijeInsertRequest();
        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            request.PutnikKorisnikId = (int)cmbPutniciKorisnici.SelectedValue;
            request.TerminPutovanjaId = (int)cmbTermini.SelectedValue;
            request.Vrijeme = dateTimePicker1.Value;
            if (_id.HasValue)
            {
                await _rezervacije.Update<Model.Rezervacije>(_id, request);
            }
            else
            {
                List<Model.Rezervacije> rezervacije = await _rezervacije.Get<List<Model.Rezervacije>>(new RezervacijeSearchRequest
                {
                    TerminId = (int?)cmbTermini.SelectedValue
                });
                var termin = await _termini.GetById<Model.TerminiPutovanja>((int?)cmbTermini.SelectedValue);
                if (termin.BrojMjesta > rezervacije.Count)
                {

                    await _rezervacije.Insert<Model.Rezervacije>(request);

                }
            }
            MessageBox.Show("Operacija uspješna");
            this.Close();
        }
    }
}
