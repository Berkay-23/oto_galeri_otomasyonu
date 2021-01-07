using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace OtoGalari_otomasyonu
{
    public partial class Form_Kayit : Form
    {
        private bool kullaniciAdiBosMu = true;
        private bool isimBosMu = true;
        private bool soyisimBosMu = true;
        private bool ePostaBosMu = true;
        private bool sifreBosMu = true;
        private bool sifreTekrarBosMu = true;
        private bool telefonNoBosMu = true;

        public Form_Kayit()
        {
            InitializeComponent();

        }
        private void Form_Register_Load(object sender, EventArgs e)
        {
            this.ActiveControl = checkBoxKosullar;
        }
        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            // Textboxlardan veriler alınıp müşteri nesnesinin nitelikleri doldurulacak oluşan nesne veri tabanına kaydedilecek

            this.ActiveControl = checkBoxKosullar;

            Musteri musteri = new Musteri();

            if (txtSifre.Text.Equals(txtSifreTekrar.Text))
            {
                if (!kullaniciAdiBosMu && !isimBosMu && !soyisimBosMu && !ePostaBosMu && !sifreBosMu && !sifreTekrarBosMu && !telefonNoBosMu && checkBoxKosullar.Checked)
                {
                    //Bu şart gerçekleşirse bütün textboxlar doldurulmuştur ve kayıt için değerlendirmeye alınabilir.

                    musteri.hataKodlari = "?";
                    musteri.KullaniciAdi = txtKullaniciAdi.Text;
                    musteri.Isim = txtIsim.Text;
                    musteri.Soyisim = txtSoyisim.Text;
                    musteri.EPosta = txtEposta.Text;
                    musteri.Sifre = txtSifre.Text;
                    musteri.TelefonNo = txtTelefonNo.Text;
                }

                if (checkBoxKosullar.Checked == false)
                {
                    // checkbox işaretlenmediyse kk6_ hata kodunu hata kodlarına ekler böylece formda uyarı sembolleri hangi textboxun yanında çıkacak belli ediliyor..
                    musteri.hataKodlari += "kk6_";
                }

                if (!musteri.hataKodlari.Equals("?"))
                {
                    // Buradaki şart bloğumuz, hata kodumuz "?" değilse yani hatamız varsa bir hata mesajı yazmak içindir.
                    string hataMesaji = "Kayıt işlemi gerçekleştiremedi :\n";

                    if (musteri.hataKodlari.Contains("ep3"))
                    {
                        hataMesaji += "●Geçersiz e-posta adresi\n";
                    }
                    if (musteri.hataKodlari.Contains("s4"))
                    {
                        hataMesaji += "●Güvenliksiz şifre\n" +
                            "Şifreniz : büyük/küçük harf rakam ve özel sembollerden en az üçünü birlikte içermeli ve min 6 karakterden oluşmalı. \n(Örn: Password_123) \n";
                    }
                    if (musteri.hataKodlari.Contains("t5"))
                    {
                        hataMesaji += "●Geçersiz telefon numarası\n";
                    }
                    if (musteri.hataKodlari.Contains("kk6"))
                    {
                        hataMesaji += "●Kullanım koşulları kabul edilmedi\n";
                    }
                    MessageBox.Show(hataMesaji, "Kayıt Yapılamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (musteri.KayitKontrol() && checkBoxKosullar.Checked)
                {
                    // Veritabanında kullanıcı adı kontrolü yapılıp kayıt işlemleri gerçekleştirilecek

                    SqlDatabase database = new SqlDatabase();

                    string BKD = "Collate SQL_Latin1_General_CP1254_CS_AS"; //Büyük-küçük harf duyarlılığını sağlayan SQL kodu.
                    string commandStr = $"SELECT COUNT(Kullanici_adi) as kontrol FROM Kullanicilar WHERE Kullanici_adi {BKD} = '{musteri.KullaniciAdi}'";

                    SqlDataReader reader = database.Reader(commandStr);

                    while (reader.Read())
                    {
                        if (Convert.ToByte(reader[0]) == 1)
                        {
                            // Kullanıcı adı daha önceden sisteme kayıt olmuştur. Müşteri başka bir kullanıcı adı bulmalıdır. 
                            MessageBox.Show("Kullanıcı adı başkası tarafından kullanılıyor. Lütfen başka bir kullanıcı adı deneyiniz.", "Kayıt yapılamadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pnlKullaniciAdi.Visible = true;
                            txtKullaniciAdi.Text = "Kullanıcı Adı";
                        }
                        else
                        {
                            // Kayıt işlemleri gerçekleşebilir.
                            try
                            {
                                string queryStr = $"INSERT INTO Kullanicilar (Kullanici_adi,Isim,Soyisim,E_posta,Sifre,Telefon_no) VALUES ('{txtKullaniciAdi.Text}','{txtIsim.Text}','{txtSoyisim.Text}','{txtEposta.Text}','{txtSifre.Text}','{txtTelefonNo.Text}')";

                                database.Add_Update_Delete(queryStr); // Ekle metoduna komudumuz göderildi.

                                DialogResult result = MessageBox.Show("KAYIT İŞLEMİNİZ GERÇEKLEŞMİŞTİR", "Kayıt tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (result == DialogResult.OK)
                                {
                                    btnBack_Click(sender, e);
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message.ToString(), "Kayıt gerçekleştirilemedi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    database.Disconnect();
                }
            }
            else
            {
                // Şifreler uyuşmuyordur ve hata kodlarına s4_ kodunu ekler böylece formda uyarı sembolleri hangi textboxun yanında çıkacak belli ediliyor.
                musteri.hataKodlari += "s4_";
                MessageBox.Show("Şifreler uyuşmuyor lütfen şifrelerinizi kontrol ediniz.", "Eşleşme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Aşağıdaki if blokları textboxların boş olması durumunda ya da hata kodunun eşleşmesi durumunda ilgili textbox un yanında uyarı işaretini aktifleştirir.

            if (kullaniciAdiBosMu || musteri.hataKodlari.Contains("ka0"))
            {
                pnlKullaniciAdi.Visible = true;
            }
            if (isimBosMu || musteri.hataKodlari.Contains("i1"))
            {
                pnlIsim.Visible = true;
            }
            if (soyisimBosMu || musteri.hataKodlari.Contains("s2"))
            {
                pnlSoyisim.Visible = true;
            }
            if (ePostaBosMu || musteri.hataKodlari.Contains("ep3"))
            {
                pnlEposta.Visible = true;
            }
            if (sifreBosMu || musteri.hataKodlari.Contains("s4"))
            {
                pnlSifre.Visible = true;
            }
            if (sifreTekrarBosMu || musteri.hataKodlari.Contains("s4"))
            {
                pnlSifreTekrar.Visible = true;
            }
            if (telefonNoBosMu || musteri.hataKodlari.Contains("t5"))
            {
                pnlTelefonNo.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Çıkış butonu 

            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Giriş formuna yönlendiren buton

            Form_Giris giris = new Form_Giris();

            this.Hide();
            giris.Show();
        }

        //
        // EVENTS START Burdan sonraki kod blokları sadece Formdaki araçların görünümünü güzelleştirmek ve bazı araçlara girilen değerlerin kontrolünü sağlamak amaçlıdır. 
        //

        char? none = null;

        private void txtKullaniciAdi_Enter(object sender, EventArgs e)
        {
            pnlKullaniciAdi.Visible = false;

            if (txtKullaniciAdi.Text == "Kullanıcı Adı")
            {
                txtKullaniciAdi.Text = null;
                txtKullaniciAdi.ForeColor = Color.White;
            }
        }

        private void txtKullaniciAdi_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            {
                kullaniciAdiBosMu = true;
                txtKullaniciAdi.ForeColor = Color.Silver;
                txtKullaniciAdi.Text = "Kullanıcı Adı";
            }
            else
            {
                kullaniciAdiBosMu = false;
            }
        }

        private void txtIsim_Enter(object sender, EventArgs e)
        {
            pnlIsim.Visible = false;

            if (txtIsim.Text == "İsim")
            {
                txtIsim.Text = null;
                txtIsim.ForeColor = Color.White;
            }
        }

        private void txtIsim_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIsim.Text))
            {
                isimBosMu = true;
                txtIsim.ForeColor = Color.Silver;
                txtIsim.Text = "İsim";
            }
            else
            {
                isimBosMu = false;
            }
        }

        private void txtSoyisim_Enter(object sender, EventArgs e)
        {
            pnlSoyisim.Visible = false;

            if (txtSoyisim.Text == "Soyisim")
            {
                txtSoyisim.Text = null;
                txtSoyisim.ForeColor = Color.White;
            }
        }

        private void txtSoyisim_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoyisim.Text))
            {
                soyisimBosMu = true;
                txtSoyisim.ForeColor = Color.Silver;
                txtSoyisim.Text = "Soyisim";
            }
            else
            {
                soyisimBosMu = false;
            }
        }

        private void txtEposta_Enter(object sender, EventArgs e)
        {
            pnlEposta.Visible = false;

            if (txtEposta.Text == "e-posta")
            {
                txtEposta.Text = null;
                txtEposta.ForeColor = Color.White;
            }
        }

        private void txtEposta_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEposta.Text))
            {
                ePostaBosMu = true;
                txtEposta.ForeColor = Color.Silver;
                txtEposta.Text = "e-posta";
            }
            else
            {
                ePostaBosMu = false;
            }
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            pnlSifre.Visible = false;

            if (txtSifre.Text == "Şifre ")
            {
                txtSifre.Text = null;
                txtSifre.ForeColor = Color.White;
                txtSifre.Properties.PasswordChar = '●';
            }
        }

        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                sifreBosMu = true;
                txtSifre.Properties.PasswordChar = Convert.ToChar(none);
                txtSifre.ForeColor = Color.Silver;
                txtSifre.Text = "Şifre ";
            }
            else
            {
                sifreBosMu = false;
            }
        }

        private void txtSifreTekrar_Enter(object sender, EventArgs e)
        {
            pnlSifreTekrar.Visible = false;

            if (txtSifreTekrar.Text == "Şifre (Tekrar)")
            {
                txtSifreTekrar.Text = null;
                txtSifreTekrar.ForeColor = Color.White;
                txtSifreTekrar.Properties.PasswordChar = '●';
            }
        }

        private void txtSifreTekrar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSifreTekrar.Text))
            {
                sifreTekrarBosMu = true;
                txtSifreTekrar.Properties.PasswordChar = Convert.ToChar(none);
                txtSifreTekrar.ForeColor = Color.Silver;
                txtSifreTekrar.Text = "Şifre (Tekrar)";
            }
            else
            {
                sifreTekrarBosMu = false;
            }
        }

        private void txtTelefonNo_Enter(object sender, EventArgs e)
        {
            pnlTelefonNo.Visible = false;

            if (txtTelefonNo.Text == "Telefon Numarası")
            {
                txtTelefonNo.Text = null;
                txtTelefonNo.ForeColor = Color.White;
            }
        }

        private void txtTelefonNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefonNo.Text))
            {
                telefonNoBosMu = true;
                txtTelefonNo.ForeColor = Color.Silver;
                txtTelefonNo.Text = "Telefon Numarası";
            }
            else
            {
                telefonNoBosMu = false;
            }
        }

        private void txtKullaniciAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Boşluk karakterinin engellenmesi için yapılmıştır
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }
        private void txtIsim_KeyPress(object sender, KeyPressEventArgs e)
        {
            // İsim bölümüne sadece harf girilebilsin diye yazılmıştır.
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void txtSoyisim_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Soyisim bölümüne sadece harf girilebilsin diye yazılmıştır.
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void txtEposta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Boşluk karakterinin engellenmesi için yapılmıştır
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Boşluk karakterinin engellenmesi için yapılmıştır
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void txtSifreTekrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Boşluk karakterinin engellenmesi için yapılmıştır
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void txtTelefonNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Telefon Numarasına sadece rakam girilebilsin diye yazılmıştır.
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSifreGoster_MouseDown(object sender, MouseEventArgs e)
        {
            // Mouse butona basılı tutulduğunda şifreyi gösterecek

            char? none = null;

            txtSifre.Properties.PasswordChar = Convert.ToChar(none);
            txtSifreTekrar.Properties.PasswordChar = Convert.ToChar(none);
        }

        private void btnSifreGoster_MouseUp(object sender, MouseEventArgs e)
        {
            // Mouse butondan çekildiğinde şifreyi gizleyecek
            if (txtSifre.Text != "Şifre ")
            {
                txtSifre.Properties.PasswordChar = '●';
            }
            
            if (txtSifreTekrar.Text != "Şifre (Tekrar)")
            {
                txtSifreTekrar.Properties.PasswordChar = '●';
            }
        }

        //
        // EVENTS END
        //
    }
}