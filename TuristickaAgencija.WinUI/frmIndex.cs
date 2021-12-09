using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuristickaAgencija.WinUI.Gradovi;

namespace TuristickaAgencija.WinUI
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        //}

        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGradovi gradovi = new frmGradovi();
            gradovi.MdiParent = this;
            gradovi.WindowState = FormWindowState.Maximized;
            gradovi.Show();
        }

        private void noviGradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gradovi.frmDetalji frm = new Gradovi.frmDetalji();

            frm.Show();
        }

        private void noviSmjestajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Smjestaj.frmDetalji frm = new Smjestaj.frmDetalji();

            frm.Show();
        }

        private void pretragaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Smjestaj.frmSmjestaj smjestaj = new Smjestaj.frmSmjestaj();
            smjestaj.MdiParent = this;
            smjestaj.WindowState = FormWindowState.Maximized;
            smjestaj.Show();
        }

        private void noviVodicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vodici.frmDetalji frm = new Vodici.frmDetalji();

            frm.Show();
        }

        private void pretragaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Vodici.frmVodici vodic = new Vodici.frmVodici();
            vodic.MdiParent = this;
            vodic.WindowState = FormWindowState.Maximized;
            vodic.Show();
        }
        //private void novaFirmaToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Drzave.frmDetalji frm = new Drzave.frmDetalji();

        //    frm.Show();
        //}

        //private void pretragaToolStripMenuItem3_Click(object sender, EventArgs e)
        //{
        //    Drzave.frmDrzave firme = new Drzave.frmDrzave();
        //    firme.MdiParent = this;
        //    firme.WindowState = FormWindowState.Maximized;
        //    firme.Show();
        //}

        private void novaFirmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Firme.frmDetalji frm = new Firme.frmDetalji();

            frm.Show();
        }

        private void pretragaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Firme.frmFirme firme = new Firme.frmFirme();
            firme.MdiParent = this;
            firme.WindowState = FormWindowState.Maximized;
            firme.Show();
        }

        private void noviPrevozToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prevoz.frmDetalji frm = new Prevoz.frmDetalji();

            frm.Show();
        }

        private void pretragaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Prevoz.frmPrevoz prevoz = new Prevoz.frmPrevoz();
            prevoz.MdiParent = this;
            prevoz.WindowState = FormWindowState.Maximized;
            prevoz.Show();
        }

        private void novoPutovanjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Putovanja.frmNovoPutovanje frm = new Putovanja.frmNovoPutovanje();

            frm.Show();
        }

        private void pretragaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Putovanja.frmPutovanja putovanja = new Putovanja.frmPutovanja();
            putovanja.MdiParent = this;
            putovanja.WindowState = FormWindowState.Maximized;
            putovanja.Show();
        }

        private void noviTerminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Termini.frmDetalji frm = new Termini.frmDetalji();

            frm.Show();
        }

        private void pretragaToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Termini.frmTermini termini = new Termini.frmTermini();
            termini.MdiParent = this;
            termini.WindowState = FormWindowState.Maximized;
            termini.Show();
        }

        //private void terminiVodiciToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Termini.frmTerminiVodici frm = new Termini.frmTerminiVodici();

        //    frm.Show();
        //}

        private void novaRezervacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rezervacije.frmDetalji frm = new Rezervacije.frmDetalji();

            frm.Show();
        }

        private void pretragaToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Rezervacije.frmRezervacije rezervacije = new Rezervacije.frmRezervacije();
            rezervacije.MdiParent = this;
            rezervacije.WindowState = FormWindowState.Maximized;
            rezervacije.Show();
        }

        private void novaUplataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uplate.frmDetalji frm = new Uplate.frmDetalji();

            frm.Show();
        }

        private void pretragaToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Uplate.frmUplate uplate = new Uplate.frmUplate();
            uplate.MdiParent = this;
            uplate.WindowState = FormWindowState.Maximized;
            uplate.Show();
        }

        private void pretragaToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            PutniciKorisnici.frmPutniciKorisnici korisnici = new PutniciKorisnici.frmPutniciKorisnici();
            korisnici.MdiParent = this;
            korisnici.WindowState = FormWindowState.Maximized;
            korisnici.Show();
        }

        private void registracijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zaposlenici.frmRegistracija frm = new Zaposlenici.frmRegistracija(); frm.Show();
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void novaPretplataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pretplate.frmPreplate frm = new Pretplate.frmPreplate(); frm.Show();

        }

        private void novaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novosti.frmDetalji frm = new Novosti.frmDetalji();

            frm.Show();
        }

        private void pretragaToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Novosti.frmNovosti novosti = new Novosti.frmNovosti();
            novosti.MdiParent = this;
            novosti.WindowState = FormWindowState.Maximized;
            novosti.Show();
        }

        private void komentariIOcjeneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Komentari.frmKomentari komentari = new Komentari.frmKomentari();
            komentari.MdiParent = this;
            komentari.WindowState = FormWindowState.Maximized;
            komentari.Show();
        }

        //private void frmIndex_Load(object sender, EventArgs e)
        //{

        //}

        //private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    OnlinePay.frmDetalji frm = new OnlinePay.frmDetalji();

        //    frm.Show();
        //}

        //private void pretragaToolStripMenuItem11_Click(object sender, EventArgs e)
        //{
        //    OnlinePay.frmOnlinePay onlinepay = new OnlinePay.frmOnlinePay();
        //    onlinepay.MdiParent = this;
        //    onlinepay.WindowState = FormWindowState.Maximized;
        //    onlinepay.Show();
        //}

        //private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{

        //}

        //private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{

        //}



        //private void vodiciToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //}
    }
}
