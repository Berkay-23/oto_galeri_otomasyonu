using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace OtoGalari_otomasyonu
{
    public partial class Form_Giris : Form
    {
        public static string userName = null;
        public static string password = null;
        public Form_Giris()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Veri tabanından kontrol yapılacak

            Form_Anasayfa anasayfa = new Form_Anasayfa();
            SqlDatabase database = new SqlDatabase();

            string BKD = "Collate SQL_Latin1_General_CP1254_CS_AS"; //Büyük-küçük harf duyarlılığını sağlayan SQL kodu.
            string commandStr = $"SELECT COUNT(Kullanici_adi) as kontrol FROM Kullanicilar WHERE Kullanici_adi {BKD} = '{txtKullaniciAdi.Text}' AND Sifre {BKD} = '{txtSifre.Text}'";

            SqlDataReader reader = database.Reader(commandStr);

            while (reader.Read())
            {
                if (Convert.ToByte(reader[0]) == 1)
                {
                    userName = txtKullaniciAdi.Text;
                    password = txtSifre.Text;
                    this.Hide();
                    anasayfa.Show();
                }
                else
                {
                   DialogResult result =  MessageBox.Show("Giriş yapılamadı kullanıcı adı ve şifrenizi kontrol ediniz" , "Giriş İşlemi Başarısız", MessageBoxButtons.OK , MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        txtKullaniciAdi.Text = null;
                        txtSifre.Text = null;
                        txtKullaniciAdi.Focus();
                    }
                }
            }
            database.Disconnect();
        }

        private void btnGoster_MouseDown(object sender, MouseEventArgs e)
        {
            // Şifre gösterme

            char? none = null;

            txtSifre.Properties.PasswordChar = Convert.ToChar(none);
        }

        private void btnGoster_MouseUp(object sender, MouseEventArgs e)
        {
            // Şifre gizleme

            txtSifre.Properties.PasswordChar = '●';
        }

        private void linkKayıtOl_Click(object sender, EventArgs e)
        {
            // Kayıt formuna yönlendirilecek

            Form_Kayit kayit = new Form_Kayit();

            this.Hide();
            kayit.Show();
        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter tuşuna basıldığında giriş yap butonuna basılacak 

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
