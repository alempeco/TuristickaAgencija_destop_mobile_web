
namespace TuristickaAgencija.WinUI.Prevoz
{
    partial class frmPrevoz
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
            this.cbFirme = new System.Windows.Forms.ComboBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.dgvPrevoz = new System.Windows.Forms.DataGridView();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.PrevozID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijenapomjestu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojMjesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipprevoza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Firma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevoz)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odaberi firmu";
            // 
            // cbFirme
            // 
            this.cbFirme.FormattingEnabled = true;
            this.cbFirme.Location = new System.Drawing.Point(28, 40);
            this.cbFirme.Name = "cbFirme";
            this.cbFirme.Size = new System.Drawing.Size(177, 21);
            this.cbFirme.TabIndex = 1;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(444, 40);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 2;
            this.btnDodaj.Text = "Novi prevoz";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnDodaj_MouseClick);
            // 
            // dgvPrevoz
            // 
            this.dgvPrevoz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPrevoz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrevoz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrevozID,
            this.Cijenapomjestu,
            this.BrojMjesta,
            this.Tipprevoza,
            this.Firma});
            this.dgvPrevoz.Location = new System.Drawing.Point(0, 144);
            this.dgvPrevoz.Name = "dgvPrevoz";
            this.dgvPrevoz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrevoz.Size = new System.Drawing.Size(773, 210);
            this.dgvPrevoz.TabIndex = 3;
            this.dgvPrevoz.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvPrevoz_MouseDoubleClick);
            // 
            // btnTrazi
            // 
            this.btnTrazi.Location = new System.Drawing.Point(235, 38);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(83, 23);
            this.btnTrazi.TabIndex = 4;
            this.btnTrazi.Text = "Pretrazi";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnTrazi_MouseClick);
            // 
            // PrevozID
            // 
            this.PrevozID.DataPropertyName = "PrevozID";
            this.PrevozID.HeaderText = "PrevozID";
            this.PrevozID.Name = "PrevozID";
            this.PrevozID.Visible = false;
            this.PrevozID.Width = 76;
            // 
            // Cijenapomjestu
            // 
            this.Cijenapomjestu.DataPropertyName = "CijenaPoMjestu";
            this.Cijenapomjestu.HeaderText = "Cijena po mjestu";
            this.Cijenapomjestu.Name = "Cijenapomjestu";
            // 
            // BrojMjesta
            // 
            this.BrojMjesta.DataPropertyName = "BrojMjesta";
            this.BrojMjesta.HeaderText = "Broj mjesta";
            this.BrojMjesta.Name = "BrojMjesta";
            this.BrojMjesta.Width = 77;
            // 
            // Tipprevoza
            // 
            this.Tipprevoza.DataPropertyName = "TipPrevoza";
            this.Tipprevoza.HeaderText = "Tip prevoza";
            this.Tipprevoza.Name = "Tipprevoza";
            this.Tipprevoza.Width = 81;
            // 
            // Firma
            // 
            this.Firma.DataPropertyName = "Firma";
            this.Firma.HeaderText = "Firma";
            this.Firma.Name = "Firma";
            this.Firma.Width = 57;
            // 
            // frmPrevoz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 352);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.dgvPrevoz);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.cbFirme);
            this.Controls.Add(this.label1);
            this.Name = "frmPrevoz";
            this.Text = "frmPrevoz";
            this.Load += new System.EventHandler(this.frmPrevoz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevoz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFirme;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DataGridView dgvPrevoz;
        private System.Windows.Forms.Button btnTrazi;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrevozID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijenapomjestu;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojMjesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipprevoza;
        private System.Windows.Forms.DataGridViewTextBoxColumn Firma;
    }
}