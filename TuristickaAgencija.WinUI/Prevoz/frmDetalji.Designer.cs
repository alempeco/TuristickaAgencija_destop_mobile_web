
namespace TuristickaAgencija.WinUI.Prevoz
{
    partial class frmDetalji
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.txtBrojMjesta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFirma = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbTipPrevoza = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cijena/ po mjestu";
            // 
            // txtCijena
            // 
            this.txtCijena.Location = new System.Drawing.Point(54, 100);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(156, 20);
            this.txtCijena.TabIndex = 3;
            this.txtCijena.Validating += new System.ComponentModel.CancelEventHandler(this.txtCijena_Validating);
            // 
            // txtBrojMjesta
            // 
            this.txtBrojMjesta.Location = new System.Drawing.Point(54, 161);
            this.txtBrojMjesta.Name = "txtBrojMjesta";
            this.txtBrojMjesta.Size = new System.Drawing.Size(156, 20);
            this.txtBrojMjesta.TabIndex = 4;
            this.txtBrojMjesta.Validating += new System.ComponentModel.CancelEventHandler(this.txtBrojMjesta_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Broj mjesta";
            // 
            // cmbFirma
            // 
            this.cmbFirma.FormattingEnabled = true;
            this.cmbFirma.Location = new System.Drawing.Point(54, 50);
            this.cmbFirma.Name = "cmbFirma";
            this.cmbFirma.Size = new System.Drawing.Size(156, 21);
            this.cmbFirma.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Firma";
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(70, 282);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(96, 23);
            this.btnSnimi.TabIndex = 10;
            this.btnSnimi.Text = "Snimi";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSnimi_MouseClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cmbTipPrevoza
            // 
            this.cmbTipPrevoza.FormattingEnabled = true;
            this.cmbTipPrevoza.Location = new System.Drawing.Point(54, 213);
            this.cmbTipPrevoza.Name = "cmbTipPrevoza";
            this.cmbTipPrevoza.Size = new System.Drawing.Size(156, 21);
            this.cmbTipPrevoza.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tip prevoza";
            // 
            // frmDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 317);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTipPrevoza);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbFirma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBrojMjesta);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.label2);
            this.Name = "frmDetalji";
            this.Text = "frmDetalji";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDetalji_FormClosing);
            this.Load += new System.EventHandler(this.frmDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.TextBox txtBrojMjesta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFirma;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipPrevoza;
    }
}