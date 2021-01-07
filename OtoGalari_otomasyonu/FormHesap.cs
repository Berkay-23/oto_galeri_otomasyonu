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
using System.IO;

namespace OtoGalari_otomasyonu
{
    public partial class Form_Hesap : Form
    {
        SqlDatabase database = new SqlDatabase();
        Form_Giris giris = new Form_Giris();

        Panel panel;
        Label label;
        PictureBox pictureBox;

        public Form_Hesap()
        {
            InitializeComponent();
        }

        private void Form_Hesap_Load(object sender, EventArgs e)
        {
            txtKullaniciAdi.Text = Form_Giris.userName;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form_Anasayfa anasayfa = new Form_Anasayfa();
            this.Hide();
            anasayfa.Show();
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            pnlGuncelle_Sil.Visible = true;
            pnlIlanlariGoster.Visible = false;
            Aktiflik(true);
            TextBoxDoldur();
        }

        private void btnHesapSil_Click(object sender, EventArgs e)
        {
            pnlGuncelle_Sil.Visible = true;
            pnlIlanlariGoster.Visible = false;
            Aktiflik(false);
            TextBoxDoldur();
        }
        private void btnIlanGoster_Click(object sender, EventArgs e)
        {
            pnlGuncelle_Sil.Visible = false;
            pnlIlanlariGoster.Visible = true;

            pnlIlanlar.Controls.Clear();

            string commandStr = $"SELECT Ilan_id, Marka, Model, Resim FROM Arac_ilanlar WHERE Ilan_sahibi = '{Form_Giris.userName}'";

            SqlDataReader reader = database.Reader(commandStr);

            int i = 0;

            while (reader.Read()) // İlanla ilgili özellikler oluşturulacak araçlar içerisnde belirtilecek
            {
                PanelEkle(i, reader[0].ToString());
                LabelEkle("İlan sahibi : " + Form_Giris.userName, 110, 75);
                LabelEkle("İlan ID = " + reader[0].ToString(), 415, 75);
                LabelEkle(reader[1].ToString() + " " + reader[2].ToString(), 110, 10);
                PictureBoxEkle(ByteArrayToImage((byte[])reader[3]));
                i++;
            }
            database.Disconnect();

            if (i == 0) // While döngümüz hiç çalışmazsa sonucumuz 0 olacağından bu durumu kullanıcıya bir label ile bildiriyoruz.
            {
                label = new Label();
                label.Text = "İlanınız bulunmamaktadır.";
                label.AutoSize = true;
                label.Location = new Point(35, 10);
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.White;
                label.Font = new System.Drawing.Font("Yu Gothic UI", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                pnlIlanlar.Controls.Add(label);
            }
        }

        private void checkbtnSifreGuncelle_CheckedChanged(object sender, EventArgs e)
        {
            // Kullanıcı şifresini güncellemek istediği zaman bu checkButon'a tıklayarak textboxların enable özelliğini açıp kapatabiliyor.
            if (checkbtnSifreGuncelle.Checked)
            {
                txtYeniSifre.Enabled = true;
                txtYeniSifreT.Enabled = true;
            }
            else
            {
                txtYeniSifre.Enabled = false;
                txtYeniSifreT.Enabled = false;

                txtYeniSifre.Text = null;
                txtYeniSifreT.Text = null;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri(); // Güncelle butonuna tıklandığında müşteri nesnesi oluşturulup özellikleri bu nesneye yükleniyor.

            musteri.KullaniciAdi = txtKullaniciAdi.Text;
            musteri.Isim = txtIsim.Text;
            musteri.Soyisim = txtSoyisim.Text;
            musteri.EPosta = txtEposta.Text;
            musteri.TelefonNo = txtTelefonNo.Text;

            if (txtYeniSifre.Text.Equals("") && txtYeniSifreT.Text.Equals("")) // Yeni şifre kutularının doluluklarının tespiti yapıldı
            {
                musteri.Sifre = Form_Giris.password; // Eğer kullanıcının yeni şifresi boşsa eski şifresini musteri sınıfının sifre özelliğine gönderiyoruz.
            }
            else
            {
                if (txtYeniSifre.Text.Equals(txtYeniSifreT.Text)) //Şifrelerin eşleşip eşleşmediğinin kontrolü yapıldı
                {
                    musteri.Sifre = txtYeniSifre.Text; // yeni şifre var ve yeni şifrelerin ikisi eşleşiyorsa musteri sınıfının sifre özelliğine yeni şifreyi gönderiyoruz.
                }
                else
                {
                    txtYeniSifre.Text = null;
                    txtYeniSifreT.Text = null;
                    txtYeniSifre.Focus();
                    musteri.hataKodlari += "es6_"; //es_6 : Şifreler eşleşmiyor hatası veriyor.
                }
            }

            if (!musteri.hataKodlari.Equals("?")) // Hata kodu sadece ? ise hiçbir hatayla karşılaşılmamıştır.
            {
                // Buradaki şart bloğumuz, hata kodumuz "?" değilse yani hatamız varsa bir hata mesajı yazmak içindir.
                string hataMesaji = "Güncelleme işlemi gerçekleştirilemedi :\n";

                if (musteri.hataKodlari.Contains("ep3")) //ep3_ : Geçersiz e posta adrei hatasını veriyor
                {
                    hataMesaji += "●Geçersiz e-posta adresi\n";
                }
                if (musteri.hataKodlari.Contains("s4")) //s4_ : Şifrenin güvenliksiz olduğu hatasını veriyor
                {
                    hataMesaji += "●Güvenliksiz şifre\n";
                }
                if (musteri.hataKodlari.Contains("t5")) //t5_ : Telefon numarasının geçersiz olduğu hatasını veriyor.
                {
                    hataMesaji += "●Geçersiz telefon numarası\n";
                }
                if (musteri.hataKodlari.Contains("es6")) //es6_ : Şifreler eşleşmiyor hatası veriyor.
                {
                    hataMesaji += "●Yeni Şifreleriniz eşleşmiyor\n";
                }
                MessageBox.Show(hataMesaji, "Hesap Bilgi Güncellemesi Yapılamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!txtSifre.Text.Equals(Form_Giris.password))
            {
                // Giriş panelinde kullanılan şifre (eski şifre) ile kullanıcının girdiği şifrenin eşleşmesi kontrol ediliyor.

                MessageBox.Show("●Eski şifrenizi hatalı girdiniz", "Hesap Bilgi Güncellemesi Yapılamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else // Güncelleme işlemleri yapılabilir hiçbir hatayla karşılaşılmamıştır.
            {
                string commandStr = $"UPDATE Kullanicilar SET " +
                    $"Isim = '{musteri.Isim}', " +
                    $"Soyisim = '{musteri.Soyisim}', " +
                    $"E_posta = '{musteri.EPosta}', " +
                    $"Sifre = '{musteri.Sifre}', " +
                    $"Telefon_no = '{musteri.TelefonNo}' " +
                    $"WHERE Kullanici_adi = '{musteri.KullaniciAdi}'";

                database.Add_Update_Delete(commandStr);

                DialogResult result = MessageBox.Show("Güncelleme işlemi başarıyla tamamlandı", "Bilgileriniz Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (DialogResult.OK == result)
                {
                    Form_Giris.password = musteri.Sifre;
                    btnBilgiGuncelle_Click(sender, e);
                }
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text.Equals(Form_Giris.password)) // Kullanıcı şifresinin doğru girildiği kontrolü yapılıyor.
            {
                DialogResult result = MessageBox.Show("Hesabınızı silmek istediğinizden emin misiniz? \nBütün ilanlarınız ve verileriniz silinecektir.", "Hesabınız Silinsin mi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) // Kullanıcı hesabı silinmesi sorusuna evet derse hesabı ve ilanları siliniyor
                {
                    string commandStr = $"DELETE FROM Kullanicilar WHERE Kullanici_adi = '{txtKullaniciAdi.Text}'";
                    database.Add_Update_Delete(commandStr); // hesap silindi

                    commandStr = $"DELETE FROM Arac_ilanlar WHERE Ilan_sahibi = '{txtKullaniciAdi.Text}'";
                    database.Add_Update_Delete(commandStr); // ilan/ilanlar silindi

                    MessageBox.Show("Hesabınız ve ilanlarınız silinmiştir", "Hesap silme işlemi başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    giris.Show();
                }
                else
                {
                    MessageBox.Show("Aramıza tekrardan hoşgeldin", "Hesabınız silinmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSifre.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Şifreniz Hatalı", "Hesabınız Silinemedi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Text = null;
            }
        }

        private void TextBoxDoldur() // Form ilk açıldığında ve paneller arası geçiş yapıldığında kullanıcı bilgilerini textboxlara doldurmak için yazılmıştır.
        {
            txtKullaniciAdi.Focus();

            checkbtnSifreGuncelle.Checked = false;
            txtSifre.Text = null;

            SqlDataReader reader = database.Reader($"SELECT * FROM Kullanicilar WHERE Kullanici_adi = '{txtKullaniciAdi.Text}'");

            while (reader.Read())
            {
                txtIsim.Text = reader[1].ToString();
                txtSoyisim.Text = reader[2].ToString();
                txtEposta.Text = reader[3].ToString();
                txtTelefonNo.Text = reader[5].ToString();
            }
            database.Disconnect();
        }
        private void Aktiflik(bool aktifMi) // kullanıcı paneller arasında dolaşırken bazı araçların görünürlük ve etkinleşme özelliklerini kapatıp açmak için yazılmıştır.
        {
            if (aktifMi)
            {
                btnSil.Visible = false;
                txtYeniSifre.Visible = true;
                txtYeniSifreT.Visible = true;
                txtIsim.Enabled = true;
                txtSoyisim.Enabled = true;
                txtEposta.Enabled = true;
                txtTelefonNo.Enabled = true;
                btnYeniSifreGoster.Visible = true;
                lblYeniSifre.Visible = true;
                lblYeniSifreT.Visible = true;
                checkbtnSifreGuncelle.Visible = true;
            }
            else
            {
                btnSil.Visible = true;
                txtYeniSifre.Visible = false;
                txtYeniSifreT.Visible = false;
                txtIsim.Enabled = false;
                txtSoyisim.Enabled = false;
                txtEposta.Enabled = false;
                txtTelefonNo.Enabled = false;
                btnYeniSifreGoster.Visible = false;
                lblYeniSifre.Visible = false;
                lblYeniSifreT.Visible = false;
                checkbtnSifreGuncelle.Visible = false;
            }
        }

        private void PanelEkle(int i, string tag) // Her ilan için ilanlar paneline yeni bir panel ekliyor
        {
            panel = new Panel();
            panel.Size = new Size(500, 100);
            panel.Location = new Point(0, 15 + (i * 105));
            panel.Tag = tag;
            panel.BackColor = Color.DarkSlateGray;
            pnlIlanlar.Controls.Add(panel);
            panel.MouseHover += Panel_MouseHover;
            panel.MouseLeave += Panel_MouseLeave;
            panel.MouseClick += Panel_MouseClick;
        }

        private void LabelEkle(string Text, int x, int y) // Her ilan paneli içindeki özelliklerin yazılacağı labelları oluşturuyor
        {
            label = new Label();
            label.Text = Text;
            label.AutoSize = true;
            label.Location = new Point(x, y);
            label.BackColor = Color.Transparent;
            label.ForeColor = Color.White;
            label.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            panel.Controls.Add(label);
        }
        private void PictureBoxEkle(Image resim) // Her ilan paneli içine picturebox ekliyor
        {
            pictureBox = new PictureBox();
            pictureBox.Size = new Size(100, 100);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox.Location = new Point(0, 0);
            pictureBox.BackColor = Color.DarkGray;
            panel.Controls.Add(pictureBox);
            pictureBox.Image = resim;
        }
        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            // İlan'a tıklandığında araç bilgilerini gösterecek

            Form_Ilan ilan = new Form_Ilan();
            Form_Anasayfa.ilanID = Convert.ToInt32(((Panel)sender).Tag);

            this.Hide();
            ilan.Show();
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            //Mouse ilanın üzerinden ayrıldığında arkaplanı eski rengine (gri) çeviriyor.
            ((Panel)sender).BackColor = Color.DarkSlateGray;
        }

        private void Panel_MouseHover(object sender, EventArgs e)
        {
            //Mouse ilanın üzerine geldiğinde arkaplanı Crimson yapıyor.
            ((Panel)sender).BackColor = Color.Crimson;
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            // byte dizisi tipinde aldığı değişkeni image formatına çeviriyor
            var memoryStream = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(memoryStream);
            return returnImage;
        }

        private void txtTelefonNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Telefon Numarasına sadece rakam girilebilsin diye yazılmıştır.
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtYeniSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Şifreye Boşluk karakteri girememesi için
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void txtYeniSifreT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Şifreye Boşluk karakteri girememesi için
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

        // Alttaki eventler şifre göster butonlarına basıldığında passwordChar özelliğini güncelliyor
        private void btnYeniSifreGoster_MouseDown(object sender, MouseEventArgs e)
        {
            char? none = null;

            txtYeniSifre.Properties.PasswordChar = Convert.ToChar(none);
            txtYeniSifreT.Properties.PasswordChar = Convert.ToChar(none);

        }
        private void btnYeniSifreGoster_MouseUp(object sender, MouseEventArgs e)
        {
            txtYeniSifre.Properties.PasswordChar = '●';
            txtYeniSifreT.Properties.PasswordChar = '●';
        }

        private void btnSifreGoster_MouseDown(object sender, MouseEventArgs e)
        {
            char? none = null;
            txtSifre.Properties.PasswordChar = Convert.ToChar(none);
        }

        private void btnSifreGoster_MouseUp(object sender, MouseEventArgs e)
        {
            txtSifre.Properties.PasswordChar = '●';
        }
    }
}
