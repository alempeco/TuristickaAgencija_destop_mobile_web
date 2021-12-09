using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuristickaAgencija.Model.Requests;

namespace TuristickaAgencija.WinUI.OnlinePay
{
    public partial class frmDetalji : Form
    {
        private int? _id = null;
        APIService _onlinePay = new APIService("OnlinePay");
        
        public frmDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmDetalji_Load(object sender, EventArgs e)
        {
            
           
                var onlinePayment = await _onlinePay.GetById<Model.OnlinePay>(_id);
                txtIznos.Text = onlinePayment.Iznos.ToString();
                txtKorisnickoIme.Text = onlinePayment.KorisnickoIme;
                txtIznos.Text = onlinePayment.DatumUplate.ToString();
                txtSvrha.Text = onlinePayment.Svrha;

                  


               


            
        }
       OnlinePayInsertRequest request = new OnlinePayInsertRequest();

        private async void btnSnimi_MouseClick(object sender, MouseEventArgs e)
        {

            


            request.Svrha = txtSvrha.Text;
            request.KorisnickoIme = txtKorisnickoIme.Text;
            request.Iznos = float.Parse (txtIznos.Text);
            request.Svrha = txtSvrha.Text;





            
                await _onlinePay.Insert<Model.Gradovi>(request);
            
           
                MessageBox.Show("Operacija uspješna!");
                this.Close();
            
        }
    }
}
