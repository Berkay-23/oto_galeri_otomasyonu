using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OtoGalari_otomasyonu
{
    public partial class Form_Ilan_Ekleme : Form
    {
        Form_Giris giris = new Form_Giris();
        Form_Anasayfa anasayfa = new Form_Anasayfa();

        public Form_Ilan_Ekleme()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            anasayfa.Show();
        }

        private void Form_Ilan_Ekleme_Load(object sender, EventArgs e)
        {
            txtIlanSahibi.Text = Form_Giris.userName;
        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            oFileDialogResim.Title = "Arabanızın fotoğrafını seçiniz";
            oFileDialogResim.FileName = "Dosya seç";
            oFileDialogResim.Filter = "Jpg Dosyaları (*.jpg)|*.jpg|Png Dosyaları (*.png)|*.png|Jpeg Dosyaları (*.jpeg)|*.jpeg";

            if (oFileDialogResim.ShowDialog() == DialogResult.OK)
            {
                pictureBoxResim.Load(oFileDialogResim.FileName);
            }
        }
        int harfSayisi = 0; // Rich textbox'a maximum 400 harf girilebileceğinden harf sayısını tutacacağımız bir değişken oluşturduk.
        private void rtxtAciklama_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblAciklamaUzunlugu.Text = rtxtAciklama.Text.Length.ToString() + "/400";
            harfSayisi += 1;

            if (rtxtAciklama.Text.Length == 400)
            {
                lblAciklamaUzunlugu.BackColor = Color.Red;
            }
            else
            {
                lblAciklamaUzunlugu.BackColor = Color.Transparent;
            }
        }

        private void btnIlanVer_Click(object sender, EventArgs e)
        {
            // Bütün araçlardaki verilerden ilan nesnesi oluşturup şartlar gerçekleşmişse kayıt işlemi gerçekleşecek

            Arac_ilan ilan = new Arac_ilan();
            rtxtAciklama.Focus();

            if (!string.IsNullOrWhiteSpace(txtKilometre.Text) && !string.IsNullOrWhiteSpace(txtFiyat.Text))
            {
                ilan.IlanSahibi = txtIlanSahibi.Text;
                ilan.Kilometre = Convert.ToInt32(txtKilometre.Text);
                ilan.Fiyat = Convert.ToInt32(txtFiyat.Text);
                ilan.MotorHacmi = comBoxMotor.Text;
                ilan.Marka = txtMarka.Text;
                ilan.Model = txtModel.Text;
                ilan.Durum = comBoxDurum.Text;
                ilan.Yakit = comBoxYakit.Text;
                ilan.Kasa = comBoxKasa.Text;
                ilan.Sanziman = comBoxSanziman.Text;
                ilan.Degisen = comBoxDegisen.Text;
                ilan.HasarKaydi = comBoxHasarKaydi.Text;
                ilan.Aciklama = rtxtAciklama.Text;

                if (ilan.Ilankontrol())
                {
                    // ilan database'e eklenecek resim update edilecek

                    SqlDatabase database = new SqlDatabase();

                    string commandStr = $"INSERT INTO Arac_ilanlar" +
                        $" (Ilan_sahibi, Marka, Model, Motor_hacmi, Sanziman, Durum, Yakit, Kasa, Degisen, Hasar_kaydi, Kilometre, Fiyat, Aciklama)" +
                        $" VALUES ('{ilan.IlanSahibi}', '{ilan.Marka}', '{ilan.Model}', '{ilan.MotorHacmi}', '{ilan.Sanziman}', '{ilan.Durum}', '{ilan.Yakit}', '{ilan.Kasa}', '{ilan.Degisen}', '{ilan.HasarKaydi}', {ilan.Kilometre}, {ilan.Fiyat}, '{ilan.Aciklama}')";

                    database.Add_Update_Delete(commandStr);

                    SqlDataReader reader = database.Reader($"SELECT Ilan_id FROM Arac_ilanlar WHERE Ilan_sahibi = '{ilan.IlanSahibi}'");

                    int Ilan_id = 0;

                    while (reader.Read())
                    {
                        if ((int)reader[0] >= Ilan_id)
                        {
                            Ilan_id = (int)reader[0];
                        }
                    }
                    database.Disconnect();

                    database.ImageUpdate(ImageToByteArray(pictureBoxResim.Image) , Ilan_id);

                    DialogResult result = MessageBox.Show("İlanınız başarıyla kaydedildi", "Kayıt işlemi başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        btnBack_Click(sender,e);
                    }
                }
                else
                {
                    MessageBox.Show("Resim ve Açıklama alanları dışındaki alanlar boş bırakılamaz", "Boş alan bıraktınız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Resim ve Açıklama alanları dışındaki alanlar boş bırakılamaz", "Boş alan bıraktınız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static byte[] ImageToByteArray(Image imageIn)
        {
            var memoryStream = new MemoryStream();
            imageIn.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            return memoryStream.ToArray();
        }
    }
}
