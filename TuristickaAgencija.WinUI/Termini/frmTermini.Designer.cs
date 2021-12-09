
namespace TuristickaAgencija.WinUI.Termini
{
    partial class frmTermini
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
            this.btnNoviTermin = new System.Windows.Forms.Button();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.cmbPutovanja = new System.Windows.Forms.ComboBox();
            this.dgvTermini = new System.Windows.Forms.DataGridView();
            this.TerminPutovanjaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminPodaci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PutovanjeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumPolaska = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumPovratka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojMjesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SmjestajId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermini)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Putovanje:";
            // 
            // btnNoviTermin
            // 
            this.btnNoviTermin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoviTermin.Location = new System.Drawing.Point(736, 53);
            this.btnNoviTermin.Name = "btnNoviTermin";
            this.btnNoviTermin.Size = new System.Drawing.Size(136, 40);
            this.btnNoviTermin.TabIndex = 7;
            this.btnNoviTermin.Text = "Novi termin";
            this.btnNoviTermin.UseVisualStyleBackColor = true;
            this.btnNoviTermin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnNoviTermin_MouseClick);
            // 
            // btnTrazi
            // 
            this.btnTrazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrazi.Location = new System.Drawing.Point(365, 42);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(75, 23);
            this.btnTrazi.TabIndex = 6;
            this.btnTrazi.Text = "Traži";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // cmbPutovanja
            // 
            this.cmbPutovanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPutovanja.FormattingEnabled = true;
            this.cmbPutovanja.Location = new System.Drawing.Point(24, 42);
            this.cmbPutovanja.Name = "cmbPutovanja";
            this.cmbPutovanja.Size = new System.Drawing.Size(335, 23);
            this.cmbPutovanja.TabIndex = 5;
            // 
            // dgvTermini
            // 
            this.dgvTermini.AllowUserToAddRows = false;
            this.dgvTermini.AllowUserToDeleteRows = false;
            this.dgvTermini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTermini.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TerminPutovanjaId,
            this.TerminPodaci,
            this.PutovanjeId,
            this.Cijena,
            this.Aktivno,
            this.DatumPolaska,
            this.DatumPovratka,
            this.BrojMjesta,
            this.SmjestajId,
            this.Slika});
            this.dgvTermini.Location = new System.Drawing.Point(24, 99);
            this.dgvTermini.Name = "dgvTermini";
            this.dgvTermini.ReadOnly = true;
            this.dgvTermini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTermini.Size = new System.Drawing.Size(848, 278);
            this.dgvTermini.TabIndex = 9;
            this.dgvTermini.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTermini_DataError);
            this.dgvTermini.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvTermini_MouseDoubleClick);
            // 
            // TerminPutovanjaId
            // 
            this.TerminPutovanjaId.DataPropertyName = "TerminPutovanjaId";
            this.TerminPutovanjaId.HeaderText = "TerminPutovanjaId";
            this.TerminPutovanjaId.Name = "TerminPutovanjaId";
            this.TerminPutovanjaId.ReadOnly = true;
            this.TerminPutovanjaId.Visible = false;
            // 
            // TerminPodaci
            // 
            this.TerminPodaci.DataPropertyName = "TerminPutovanjaPodaci";
            this.TerminPodaci.HeaderText = "Termin";
            this.TerminPodaci.Name = "TerminPodaci";
            this.TerminPodaci.ReadOnly = true;
            // 
            // PutovanjeId
            // 
            this.PutovanjeId.DataPropertyName = "PutovanjeId";
            this.PutovanjeId.HeaderText = "Putovanje";
            this.PutovanjeId.Name = "PutovanjeId";
            this.PutovanjeId.ReadOnly = true;
            this.PutovanjeId.Visible = false;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // Aktivno
            // 
            this.Aktivno.DataPropertyName = "Aktivno";
            this.Aktivno.HeaderText = "Aktivno";
            this.Aktivno.Name = "Aktivno";
            this.Aktivno.ReadOnly = true;
            // 
            // DatumPolaska
            // 
            this.DatumPolaska.DataPropertyName = "DatumPolaska";
            this.DatumPolaska.HeaderText = "Datum polaska";
            this.DatumPolaska.Name = "DatumPolaska";
            this.DatumPolaska.ReadOnly = true;
            // 
            // DatumPovratka
            // 
            this.DatumPovratka.DataPropertyName = "DatumPovratka";
            this.DatumPovratka.HeaderText = "Datum povratka";
            this.DatumPovratka.Name = "DatumPovratka";
            this.DatumPovratka.ReadOnly = true;
            // 
            // BrojMjesta
            // 
            this.BrojMjesta.DataPropertyName = "BrojMjesta";
            this.BrojMjesta.HeaderText = "Broj mjesta";
            this.BrojMjesta.Name = "BrojMjesta";
            this.BrojMjesta.ReadOnly = true;
            // 
            // SmjestajId
            // 
            this.SmjestajId.DataPropertyName = "Smjestaj";
            this.SmjestajId.HeaderText = "Smještaj";
            this.SmjestajId.Name = "SmjestajId";
            this.SmjestajId.ReadOnly = true;
            // 
            // Slika
            // 
            this.Slika.DataPropertyName = "Slika";
            this.Slika.HeaderText = "Slika";
            this.Slika.Name = "Slika";
            this.Slika.ReadOnly = true;
            // 
            // frmTermini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 397);
            this.Controls.Add(this.dgvTermini);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNoviTermin);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.cmbPutovanja);
            this.Name = "frmTermini";
            this.Text = "frmTermini";
            this.Load += new System.EventHandler(this.frmTermini_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermini)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNoviTermin;
        private System.Windows.Forms.Button btnTrazi;
        private System.Windows.Forms.ComboBox cmbPutovanja;
        private System.Windows.Forms.DataGridView dgvTermini;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminPutovanjaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminPodaci;
        private System.Windows.Forms.DataGridViewTextBoxColumn PutovanjeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aktivno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumPolaska;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumPovratka;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojMjesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn SmjestajId;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
    }
}