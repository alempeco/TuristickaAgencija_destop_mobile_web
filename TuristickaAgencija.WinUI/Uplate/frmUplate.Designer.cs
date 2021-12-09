
namespace TuristickaAgencija.WinUI.Uplate
{
    partial class frmUplate
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRezervacije = new System.Windows.Forms.ComboBox();
            this.dgvUplate = new System.Windows.Forms.DataGridView();
            this.UplataId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RezervacijaPodaci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumUplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUplate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDodaj
            // 
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.Location = new System.Drawing.Point(667, 30);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(115, 23);
            this.btnDodaj.TabIndex = 10;
            this.btnDodaj.Text = "Nova uplata";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnTrazi
            // 
            this.btnTrazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrazi.Location = new System.Drawing.Point(582, 29);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(79, 24);
            this.btnTrazi.TabIndex = 9;
            this.btnTrazi.Text = "Traži";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Rezervacije:";
            // 
            // cmbRezervacije
            // 
            this.cmbRezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRezervacije.FormattingEnabled = true;
            this.cmbRezervacije.Location = new System.Drawing.Point(12, 30);
            this.cmbRezervacije.Name = "cmbRezervacije";
            this.cmbRezervacije.Size = new System.Drawing.Size(564, 23);
            this.cmbRezervacije.TabIndex = 7;
            // 
            // dgvUplate
            // 
            this.dgvUplate.AllowUserToAddRows = false;
            this.dgvUplate.AllowUserToDeleteRows = false;
            this.dgvUplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UplataId,
            this.RezervacijaPodaci,
            this.DatumUplate,
            this.Iznos});
            this.dgvUplate.Location = new System.Drawing.Point(12, 84);
            this.dgvUplate.Name = "dgvUplate";
            this.dgvUplate.ReadOnly = true;
            this.dgvUplate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUplate.Size = new System.Drawing.Size(770, 294);
            this.dgvUplate.TabIndex = 11;
            this.dgvUplate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvUplate_MouseDoubleClick);
            // 
            // UplataId
            // 
            this.UplataId.DataPropertyName = "UplataId";
            this.UplataId.HeaderText = "UplataId";
            this.UplataId.Name = "UplataId";
            this.UplataId.ReadOnly = true;
            this.UplataId.Visible = false;
            // 
            // RezervacijaPodaci
            // 
            this.RezervacijaPodaci.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RezervacijaPodaci.DataPropertyName = "RezervacijaPodaci";
            this.RezervacijaPodaci.HeaderText = "RezervacijaPodaci";
            this.RezervacijaPodaci.Name = "RezervacijaPodaci";
            this.RezervacijaPodaci.ReadOnly = true;
            // 
            // DatumUplate
            // 
            this.DatumUplate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DatumUplate.DataPropertyName = "DatumUplate";
            this.DatumUplate.HeaderText = "Datum uplate";
            this.DatumUplate.Name = "DatumUplate";
            this.DatumUplate.ReadOnly = true;
            // 
            // Iznos
            // 
            this.Iznos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Iznos.DataPropertyName = "Iznos";
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.Name = "Iznos";
            this.Iznos.ReadOnly = true;
            // 
            // frmUplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 401);
            this.Controls.Add(this.dgvUplate);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbRezervacije);
            this.Name = "frmUplate";
            this.Text = "frmUplate";
            this.Load += new System.EventHandler(this.frmUplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnTrazi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRezervacije;
        private System.Windows.Forms.DataGridView dgvUplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UplataId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RezervacijaPodaci;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumUplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
    }
}