
namespace TuristickaAgencija.WinUI.Vodici
{
    partial class frmVodici
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbZauzet = new System.Windows.Forms.CheckBox();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.btnNovi = new System.Windows.Forms.Button();
            this.dgvVodici = new System.Windows.Forms.DataGridView();
            this.VodicID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kontakt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JMBG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVodici)).BeginInit();
            this.SuspendLayout();
            // 
            // cbZauzet
            // 
            this.cbZauzet.AutoSize = true;
            this.cbZauzet.Location = new System.Drawing.Point(31, 42);
            this.cbZauzet.Name = "cbZauzet";
            this.cbZauzet.Size = new System.Drawing.Size(59, 17);
            this.cbZauzet.TabIndex = 0;
            this.cbZauzet.Text = "Zauzet";
            this.cbZauzet.UseVisualStyleBackColor = true;
            // 
            // btnTrazi
            // 
            this.btnTrazi.Location = new System.Drawing.Point(115, 38);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(100, 23);
            this.btnTrazi.TabIndex = 1;
            this.btnTrazi.Text = "Pretrazi";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // btnNovi
            // 
            this.btnNovi.Location = new System.Drawing.Point(497, 42);
            this.btnNovi.Name = "btnNovi";
            this.btnNovi.Size = new System.Drawing.Size(142, 23);
            this.btnNovi.TabIndex = 2;
            this.btnNovi.Text = "Novi vodic";
            this.btnNovi.UseVisualStyleBackColor = true;
            this.btnNovi.Click += new System.EventHandler(this.btnNovi_Click);
            // 
            // dgvVodici
            // 
            this.dgvVodici.AllowUserToAddRows = false;
            this.dgvVodici.AllowUserToDeleteRows = false;
            this.dgvVodici.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVodici.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVodici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVodici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VodicID,
            this.Ime,
            this.Prezime,
            this.Kontakt,
            this.JMBG,
            this.Slika});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVodici.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVodici.Location = new System.Drawing.Point(-2, 87);
            this.dgvVodici.Name = "dgvVodici";
            this.dgvVodici.ReadOnly = true;
            this.dgvVodici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVodici.Size = new System.Drawing.Size(870, 284);
            this.dgvVodici.TabIndex = 3;
            this.dgvVodici.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvVodici_DataError);
            this.dgvVodici.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvVodici_MouseDoubleClick);
            // 
            // VodicID
            // 
            this.VodicID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.VodicID.DataPropertyName = "VodicID";
            this.VodicID.HeaderText = "VodicID";
            this.VodicID.Name = "VodicID";
            this.VodicID.ReadOnly = true;
            this.VodicID.Visible = false;
            this.VodicID.Width = 5;
            // 
            // Ime
            // 
            this.Ime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // Kontakt
            // 
            this.Kontakt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Kontakt.DataPropertyName = "Kontakt";
            this.Kontakt.HeaderText = "Kontakt broj";
            this.Kontakt.Name = "Kontakt";
            this.Kontakt.ReadOnly = true;
            // 
            // JMBG
            // 
            this.JMBG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.JMBG.DataPropertyName = "JMBG";
            this.JMBG.HeaderText = "JMBG";
            this.JMBG.Name = "JMBG";
            this.JMBG.ReadOnly = true;
            // 
            // Slika
            // 
            this.Slika.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Slika.DataPropertyName = "Slika";
            this.Slika.HeaderText = "Slika";
            this.Slika.Name = "Slika";
            this.Slika.ReadOnly = true;
            this.Slika.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Slika.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmVodici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 372);
            this.Controls.Add(this.dgvVodici);
            this.Controls.Add(this.btnNovi);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.cbZauzet);
            this.Name = "frmVodici";
            this.Text = "frmVodici";
            this.Load += new System.EventHandler(this.frmVodici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVodici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbZauzet;
        private System.Windows.Forms.Button btnTrazi;
        private System.Windows.Forms.Button btnNovi;
        private System.Windows.Forms.DataGridView dgvVodici;
        private System.Windows.Forms.DataGridViewTextBoxColumn VodicID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kontakt;
        private System.Windows.Forms.DataGridViewTextBoxColumn JMBG;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
    }
}