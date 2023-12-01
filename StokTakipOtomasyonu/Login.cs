using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipOtomasyonu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        KullaniciDAL dAL=new KullaniciDAL();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            var sonuc=dAL.KullaniciGiris(txtKullanici.Text,txtSifre.Text);
            if (sonuc)
            {
               Form1 form1=new Form1();
               
                form1.Show();
                
                
                this.Hide();
                MessageBox.Show("Giriş Başarılı!");
            }
            else
            {
                MessageBox.Show("Giriş Başarısız!");
            }
             
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
