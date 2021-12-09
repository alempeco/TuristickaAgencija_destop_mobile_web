
namespace TuristickaAgencija.WinUI.Novosti
{
    partial class frmNovosti
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
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.cmbPutovanja = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNovosti = new System.Windows.Forms.DataGridView();
            this.NovostID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naslov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sadrzaj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumVrijeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            this.PutovanjeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNovosti)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDodaj
            // 
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.Location = new System.Drawing.Point(669, 42);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(113, 23);
            this.btnDodaj.TabIndex = 8;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnTrazi
            // 
            this.btnTrazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrazi.Location = new System.Drawing.Point(268, 42);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(75, 23);
            this.btnTrazi.TabIndex = 7;
            this.btnTrazi.Text = "Traži";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // cmbPutovanja
            // 
            this.cmbPutovanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPutovanja.FormattingEnabled = true;
            this.cmbPutovanja.Location = new System.Drawing.Point(12, 42);
            this.cmbPutovanja.Name = "cmbPutovanja";
            this.cmbPutovanja.Size = new System.Drawing.Size(222, 23);
            this.cmbPutovanja.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Putovanje";
            // 
            // dgvNovosti
            // 
            this.dgvNovosti.AllowUserToAddRows = false;
            this.dgvNovosti.AllowUserToDeleteRows = false;
            this.dgvNovosti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNovosti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NovostID,
            this.Naslov,
            this.Sadrzaj,
            this.DatumVrijeme,
            this.Slika,
            this.PutovanjeID});
            this.dgvNovosti.Location = new System.Drawing.Point(12, 87);
            this.dgvNovosti.Name = "dgvNovosti";
            this.dgvNovosti.ReadOnly = true;
            this.dgvNovosti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNovosti.Size = new System.Drawing.Size(764, 280);
            this.dgvNovosti.TabIndex = 9;
            this.dgvNovosti.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNovosti_CellContentClick);
            this.dgvNovosti.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvNovosti_DataError);
            // 
            // NovostID
            // 
            this.NovostID.DataPropertyName = "NovostID";
            this.NovostID.HeaderText = "NovostID";
            this.NovostID.Name = "NovostID";
            this.NovostID.ReadOnly = true;
            this.NovostID.Visible = false;
            // 
            // Naslov
            // 
            this.Naslov.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Naslov.DataPropertyName = "Naslov";
            this.Naslov.HeaderText = "Naslov";
            this.Naslov.Name = "Naslov";
            this.Naslov.ReadOnly = true;
            // 
            // Sadrzaj
            // 
            this.Sadrzaj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sadrzaj.DataPropertyName = "Sadrzaj";
            this.Sadrzaj.HeaderText = "Sadrzaj";
            this.Sadrzaj.Name = "Sadrzaj";
            this.Sadrzaj.ReadOnly = true;
            // 
            // DatumVrijeme
            // 
            this.DatumVrijeme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DatumVrijeme.DataPropertyName = "DatumVrijeme";
            this.DatumVrijeme.HeaderText = "Vrijeme";
            this.DatumVrijeme.Name = "DatumVrijeme";
            this.DatumVrijeme.ReadOnly = true;
            // 
            // Slika
            // 
            this.Slika.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Slika.DataPropertyName = "Slika";
            this.Slika.HeaderText = "Slika";
            this.Slika.Name = "Slika";
            this.Slika.ReadOnly = true;
            // 
            // PutovanjeID
            // 
            this.PutovanjeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PutovanjeID.DataPropertyName = "Putovanje";
            this.PutovanjeID.HeaderText = "Putovanje";
            this.PutovanjeID.Name = "PutovanjeID";
            this.PutovanjeID.ReadOnly = true;
            // 
            // frmNovosti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvNovosti);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.cmbPutovanja);
            this.Controls.Add(this.label1);
            this.Name = "frmNovosti";
            this.Text = "frmNovosti";
            this.Load += new System.EventHandler(this.frmNovosti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNovosti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnTrazi;
        private System.Windows.Forms.ComboBox cmbPutovanja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvNovosti;
        private System.Windows.Forms.DataGridViewTextBoxColumn NovostID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naslov;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sadrzaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumVrijeme;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
        private System.Windows.Forms.DataGridViewTextBoxColumn PutovanjeID;
    }
}