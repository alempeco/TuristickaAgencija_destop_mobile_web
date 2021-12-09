
namespace TuristickaAgencija.WinUI.Drzave
{
    partial class frmDrzave
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
            this.dgvFirme = new System.Windows.Forms.DataGridView();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.txtPretragaNaziv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DrzaveID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nazivfirme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFirme)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFirme
            // 
            this.dgvFirme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFirme.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DrzaveID,
            this.Nazivfirme});
            this.dgvFirme.Location = new System.Drawing.Point(17, 130);
            this.dgvFirme.Name = "dgvFirme";
            this.dgvFirme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFirme.Size = new System.Drawing.Size(660, 130);
            this.dgvFirme.TabIndex = 7;
            this.dgvFirme.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvFirme_MouseDoubleClick);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(442, 45);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 6;
            this.btnDodaj.Text = "Nova drzava";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // txtPretragaNaziv
            // 
            this.txtPretragaNaziv.Location = new System.Drawing.Point(17, 48);
            this.txtPretragaNaziv.Name = "txtPretragaNaziv";
            this.txtPretragaNaziv.Size = new System.Drawing.Size(161, 20);
            this.txtPretragaNaziv.TabIndex = 5;
            this.txtPretragaNaziv.TextChanged += new System.EventHandler(this.txtPretragaNaziv_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Naziv drzave";
            // 
            // DrzaveID
            // 
            this.DrzaveID.DataPropertyName = "DrzaveID";
            this.DrzaveID.HeaderText = "DrzaveID";
            this.DrzaveID.Name = "DrzaveID";
            this.DrzaveID.Visible = false;
            // 
            // Nazivfirme
            // 
            this.Nazivfirme.DataPropertyName = "NazivDrzave";
            this.Nazivfirme.HeaderText = "Naziv drzave";
            this.Nazivfirme.Name = "Nazivfirme";
            // 
            // frmDrzave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 306);
            this.Controls.Add(this.dgvFirme);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.txtPretragaNaziv);
            this.Controls.Add(this.label1);
            this.Name = "frmDrzave";
            this.Text = "frmDrzave";
            this.Load += new System.EventHandler(this.frmDrzave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFirme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFirme;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.TextBox txtPretragaNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrzaveID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazivfirme;
    }
}