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

namespace TuristickaAgencija.WinUI.Zaposlenici
{
    public partial class frmRegistracija : Form
    {
        APIService _zaposlenici = new APIService("Zaposlenici");

        public frmRegistracija()
        {
            InitializeComponent();

        }



        ZaposleniciInsertRequest request = new ZaposleniciInsertRequest();
        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            request.Ime = txtIme.Text;
            request.Prezime = txtPrezime.Text;
            request.Email = txtEmail.Text;
            request.Kontakt = txtKontakt.Text;
            request.KorisnickoIme = txtKorisnickoIme.Text;
            request.Password = txtLozinka.Text;
            request.PasswordPotvrda = txtLozinkaPotvrda.Text;

            await _zaposlenici.Insert<Model.Zaposlenici>(request);

            MessageBox.Show("Zaposlenik je uspješno registrovan!");
            this.Close();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
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
                errorProvider1.SetError(txtIme, "Ime smije da sadrzi samo slova");
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
                errorProvider1.SetError(txtPrezime, "Prezime mora da sadrzi samo slova!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPrezime, null);

            }
        }

        private void txtMail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Ovo polje je obavezno.");
                e.Cancel = true;
            }
            //else if (!Regex.IsMatch(txtEmail.Text, @"[a - z0 - 9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
            //{
            //    errorProvider1.SetError(txtEmail, "Pravilan format example@example.com");
            //    e.Cancel = true;
            //}
            else
            {
                errorProvider1.SetError(txtEmail, null);


            }
        }

        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text))
            {
                errorProvider1.SetError(txtKorisnickoIme, "Ovo polje je obavezno.");
                e.Cancel = true;
            }
            else if (txtKorisnickoIme.Text.Length < 3)
            {
                errorProvider1.SetError(txtKorisnickoIme, "Mora da sadrži minimalno 3 slova.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtKorisnickoIme, null);


            }
        }

        private void txtLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLozinka.Text))
            {
                errorProvider1.SetError(txtLozinka, "Ovo polje je obavezno.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtLozinka, null);


            }
        }


        private void txtKontakt_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtKontakt.Text, @"^?\(?\d{3}?\)??-??\(?\d{3}?\)??-??\(?\d{3,}?\)??-?$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtKontakt, "Neispravan format. Ovo polje mora biti u formatu (036)576-678 ili 123-456-7890 ili 045678543");
            }
            else
            {
                errorProvider1.SetError(txtKontakt, null);


            }
        }

        private void txtLozinkaPotvrda_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLozinkaPotvrda.Text))
            {
                errorProvider1.SetError(txtLozinkaPotvrda, "Ovo polje je obavezno.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtLozinkaPotvrda, null);


            }
        }

        private void frmRegistracija_FormClosing(object sender, FormClosingEventArgs e)
        {
            errorProvider1.Clear();
            e.Cancel = false;
        }
    }
}
