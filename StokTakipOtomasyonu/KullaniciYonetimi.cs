using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipOtomasyonu
{
    public partial class KullaniciYonetimi : Form
    {
        public KullaniciYonetimi()
        {
            InitializeComponent();
        }
        UserDAL userDAL = new UserDAL();
        void Temizle()
        {
            txtFirstName.Text=string.Empty;
            txtLastName.Text=string.Empty;  
            txtEmail.Text=string.Empty;
            txtPassword.Text=string.Empty;
            txtUserName.Text=string.Empty;

            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled=false;
        }
        private void KullaniciYonetimi_Load(object sender, EventArgs e)
        {
            dgvUserlar.DataSource = userDAL.UserlariDatatableileGetir();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = userDAL.Add(new User()
                {    
                    FirstName=txtFirstName.Text,
                    LastName=txtLastName.Text,
                    Password=txtPassword.Text,
                    UserName=txtUserName.Text,
                    Email=txtEmail.Text,
                });
                if (sonuc > 0)
                {
                    Temizle();
                    dgvUserlar.DataSource =
                    userDAL.UserlariDatatableileGetir();
                    MessageBox.Show("Kayıt Başarılı!");
                }
                else
                    MessageBox.Show("Hata Oluştu!");
            
            }
            
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu!");
            }
            
        }

        private void dgvUserlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvUserlar.CurrentRow.Cells[0].Value);
                User kayit = userDAL.Get(id);
                txtEmail.Text = kayit.Email;
                txtFirstName.Text = kayit.FirstName;
                txtLastName.Text = kayit.LastName;
                txtPassword.Text = kayit.Password;
                txtUserName.Text = kayit.UserName;
                btnEkle.Enabled = false;
                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = userDAL.Update(new User()
                {
                    Id = Convert.ToInt32(dgvUserlar.CurrentRow.Cells[0].Value),
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text,
                    Email = txtEmail.Text,
                });
                if(sonuc>0)
                {
                    Temizle();
                    dgvUserlar.DataSource =
                        userDAL.UserlariDatatableileGetir();
                    MessageBox.Show("Kayıt Başarılı!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dgvUserlar.CurrentRow.Cells[0].Value;
                var sonuc = userDAL.Delete(id);
                if (sonuc > 0)
                {
                    Temizle();
                    dgvUserlar.DataSource =
                        userDAL.UserlariDatatableileGetir();
                    MessageBox.Show("Silme Başarılı!");
                }
                else
                    MessageBox.Show("Kayıt Silinemedi!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }
    }
}
