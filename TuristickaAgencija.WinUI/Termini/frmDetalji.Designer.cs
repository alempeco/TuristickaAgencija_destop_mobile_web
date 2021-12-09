
namespace TuristickaAgencija.WinUI.Termini
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
            this.txtSlika = new System.Windows.Forms.TextBox();
            this.btnUcitaj = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPutovanja = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBrojMjesta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSmjestaj = new System.Windows.Forms.ComboBox();
            this.cbAktivno = new System.Windows.Forms.CheckBox();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.dateTimeDO = new System.Windows.Forms.DateTimePicker();
            this.dateTimeOD = new System.Windows.Forms.DateTimePicker();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cmbVodic = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSlika
            // 
            this.txtSlika.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlika.Location = new System.Drawing.Point(518, 251);
            this.txtSlika.Name = "txtSlika";
            this.txtSlika.Size = new System.Drawing.Size(180, 21);
            this.txtSlika.TabIndex = 36;
            // 
            // btnUcitaj
            // 
            this.btnUcitaj.Location = new System.Drawing.Point(518, 275);
            this.btnUcitaj.Name = "btnUcitaj";
            this.btnUcitaj.Size = new System.Drawing.Size(180, 23);
            this.btnUcitaj.TabIndex = 35;
            this.btnUcitaj.Text = "Učitaj...";
            this.btnUcitaj.UseVisualStyleBackColor = true;
            this.btnUcitaj.Click += new System.EventHandler(this.btnUcitaj_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(518, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Putovanje:";
            // 
            // cmbPutovanja
            // 
            this.cmbPutovanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPutovanja.FormattingEnabled = true;
            this.cmbPutovanja.Location = new System.Drawing.Point(49, 28);
            this.cmbPutovanja.Name = "cmbPutovanja";
            this.cmbPutovanja.Size = new System.Drawing.Size(412, 23);
            this.cmbPutovanja.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(52, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Broj mjesta:";
            // 
            // txtBrojMjesta
            // 
            this.txtBrojMjesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrojMjesta.Location = new System.Drawing.Point(49, 297);
            this.txtBrojMjesta.Name = "txtBrojMjesta";
            this.txtBrojMjesta.Size = new System.Drawing.Size(200, 21);
            this.txtBrojMjesta.TabIndex = 30;
            this.txtBrojMjesta.Validating += new System.ComponentModel.CancelEventHandler(this.txtBrojMjesta_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(280, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Termin aktivnan?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(258, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Smještaj:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Cijena:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Vrijeme termina (OD-DO):";
            // 
            // cmbSmjestaj
            // 
            this.cmbSmjestaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSmjestaj.FormattingEnabled = true;
            this.cmbSmjestaj.Location = new System.Drawing.Point(255, 210);
            this.cmbSmjestaj.Name = "cmbSmjestaj";
            this.cmbSmjestaj.Size = new System.Drawing.Size(200, 23);
            this.cmbSmjestaj.TabIndex = 25;
            // 
            // cbAktivno
            // 
            this.cbAktivno.AutoSize = true;
            this.cbAktivno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAktivno.Location = new System.Drawing.Point(394, 295);
            this.cbAktivno.Name = "cbAktivno";
            this.cbAktivno.Size = new System.Drawing.Size(46, 20);
            this.cbAktivno.TabIndex = 24;
            this.cbAktivno.Text = "DA";
            this.cbAktivno.UseVisualStyleBackColor = true;
            // 
            // txtCijena
            // 
            this.txtCijena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCijena.Location = new System.Drawing.Point(49, 210);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(200, 21);
            this.txtCijena.TabIndex = 23;
            this.txtCijena.Validating += new System.ComponentModel.CancelEventHandler(this.txtCijena_Validating);
            // 
            // dateTimeDO
            // 
            this.dateTimeDO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeDO.Location = new System.Drawing.Point(255, 137);
            this.dateTimeDO.Name = "dateTimeDO";
            this.dateTimeDO.Size = new System.Drawing.Size(200, 21);
            this.dateTimeDO.TabIndex = 22;
            this.dateTimeDO.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimeDO_Validating);
            // 
            // dateTimeOD
            // 
            this.dateTimeOD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeOD.Location = new System.Drawing.Point(49, 137);
            this.dateTimeOD.Name = "dateTimeOD";
            this.dateTimeOD.Size = new System.Drawing.Size(200, 21);
            this.dateTimeOD.TabIndex = 21;
            // 
            // btnSnimi
            // 
            this.btnSnimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnimi.Location = new System.Drawing.Point(192, 363);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(129, 37);
            this.btnSnimi.TabIndex = 37;
            this.btnSnimi.Text = "Sačuvaj";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(52, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 41;
            this.label8.Text = "Vodic:";
            // 
            // cmbVodic
            // 
            this.cmbVodic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVodic.FormattingEnabled = true;
            this.cmbVodic.Location = new System.Drawing.Point(49, 81);
            this.cmbVodic.Name = "cmbVodic";
            this.cmbVodic.Size = new System.Drawing.Size(200, 23);
            this.cmbVodic.TabIndex = 40;
            // 
            // frmDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 412);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbVodic);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.txtSlika);
            this.Controls.Add(this.btnUcitaj);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPutovanja);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBrojMjesta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSmjestaj);
            this.Controls.Add(this.cbAktivno);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.dateTimeDO);
            this.Controls.Add(this.dateTimeOD);
            this.Name = "frmDetalji";
            this.Text = "frmDetalji";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDetalji_FormClosing);
            this.Load += new System.EventHandler(this.frmDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSlika;
        private System.Windows.Forms.Button btnUcitaj;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPutovanja;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBrojMjesta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSmjestaj;
        private System.Windows.Forms.CheckBox cbAktivno;
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.DateTimePicker dateTimeDO;
        private System.Windows.Forms.DateTimePicker dateTimeOD;
        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbVodic;
    }
}