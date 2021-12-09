
namespace TuristickaAgencija.WinUI.Smjestaj
{
    partial class frmSmjestaj
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbGradovi = new System.Windows.Forms.ComboBox();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.dgvSmjestaj = new System.Windows.Forms.DataGridView();
            this.SmjestajID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CijenaNoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipSobe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSmjestaj)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(33, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odaberi grad";
            // 
            // cbGradovi
            // 
            this.cbGradovi.FormattingEnabled = true;
            this.cbGradovi.Location = new System.Drawing.Point(36, 61);
            this.cbGradovi.Name = "cbGradovi";
            this.cbGradovi.Size = new System.Drawing.Size(174, 21);
            this.cbGradovi.TabIndex = 1;
            // 
            // btnTrazi
            // 
            this.btnTrazi.Location = new System.Drawing.Point(243, 61);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(75, 23);
            this.btnTrazi.TabIndex = 2;
            this.btnTrazi.Text = "Pretraži";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnTrazi_MouseClick);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(452, 61);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(110, 23);
            this.btnDodaj.TabIndex = 3;
            this.btnDodaj.Text = "Novi smještaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnDodaj_MouseClick);
            // 
            // dgvSmjestaj
            // 
            this.dgvSmjestaj.AllowUserToAddRows = false;
            this.dgvSmjestaj.AllowUserToDeleteRows = false;
            this.dgvSmjestaj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSmjestaj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSmjestaj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SmjestajID,
            this.Naziv,
            this.CijenaNoc,
            this.TipSobe,
            this.GradID,
            this.Slika});
            this.dgvSmjestaj.Location = new System.Drawing.Point(-4, 135);
            this.dgvSmjestaj.Name = "dgvSmjestaj";
            this.dgvSmjestaj.ReadOnly = true;
            this.dgvSmjestaj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSmjestaj.Size = new System.Drawing.Size(857, 208);
            this.dgvSmjestaj.TabIndex = 4;
            this.dgvSmjestaj.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvSmjestaj_MouseDoubleClick);
            // 
            // SmjestajID
            // 
            this.SmjestajID.DataPropertyName = "SmjestajID";
            this.SmjestajID.HeaderText = "SmjestajID";
            this.SmjestajID.Name = "SmjestajID";
            this.SmjestajID.ReadOnly = true;
            this.SmjestajID.Visible = false;
            this.SmjestajID.Width = 82;
            // 
            // Naziv
            // 
            this.Naziv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.FillWeight = 61.54822F;
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // CijenaNoc
            // 
            this.CijenaNoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CijenaNoc.DataPropertyName = "CijenaNoc";
            this.CijenaNoc.FillWeight = 61.54822F;
            this.CijenaNoc.HeaderText = "Cijena/Noc";
            this.CijenaNoc.Name = "CijenaNoc";
            this.CijenaNoc.ReadOnly = true;
            // 
            // TipSobe
            // 
            this.TipSobe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TipSobe.DataPropertyName = "TipSobe";
            this.TipSobe.FillWeight = 61.54822F;
            this.TipSobe.HeaderText = "TipSobe";
            this.TipSobe.Name = "TipSobe";
            this.TipSobe.ReadOnly = true;
            // 
            // GradID
            // 
            this.GradID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GradID.DataPropertyName = "Grad";
            this.GradID.FillWeight = 61.54822F;
            this.GradID.HeaderText = "Grad";
            this.GradID.Name = "GradID";
            this.GradID.ReadOnly = true;
            // 
            // Slika
            // 
            this.Slika.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Slika.DataPropertyName = "Slika";
            this.Slika.FillWeight = 253.8071F;
            this.Slika.HeaderText = "Slika";
            this.Slika.MinimumWidth = 100;
            this.Slika.Name = "Slika";
            this.Slika.ReadOnly = true;
            // 
            // frmSmjestaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 339);
            this.Controls.Add(this.dgvSmjestaj);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.cbGradovi);
            this.Controls.Add(this.label1);
            this.Name = "frmSmjestaj";
            this.Text = "frmSmjestaj";
            this.Load += new System.EventHandler(this.frmSmjestaj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSmjestaj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbGradovi;
        private System.Windows.Forms.Button btnTrazi;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DataGridView dgvSmjestaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn SmjestajID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn CijenaNoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipSobe;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradID;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
    }
}