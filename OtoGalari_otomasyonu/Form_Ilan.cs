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
    public partial class Form_Ilan : Form
    {
        Form_Anasayfa anasayfa = new Form_Anasayfa();
        SqlDatabase database = new SqlDatabase();
        public Form_Ilan()
        {
            InitializeComponent();
        }
        private void Form_Ilan_Load(object sender, EventArgs e)
        {
            string BKD = "Collate SQL_Latin1_General_CP1254_CS_AS"; //Büyük-küçük harf duyarlılığını sağlayan SQL kodu.
            string commandStr = $"SELECT COUNT(Ilan_id) as kontrol FROM Arac_ilanlar WHERE Ilan_sahibi {BKD} = '{Form_Giris.userName}' AND Ilan_id = {Form_Anasayfa.ilanID}";

            SqlDataReader reader = database.Reader(commandStr);

            while (reader.Read())
            {
                if (Convert.ToInt32(reader[0]) == 1)
                {
                    pnlKontrol.Visible = true;
                }
                else
                {
                    pnlKontrol.Visible = false;
                }
            }
            database.Disconnect();

            KutulariDoldur();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            anasayfa.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkbtnGuncelle_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbtnGuncelle.Checked)
            {
                txtMarka.Enabled = true;
                txtModel.Enabled = true;
                cBoxMotorHacmi.Enabled = true;
                cBoxSanziman.Enabled = true;
                cBoxDurum.Enabled = true;
                cBoxYakit.Enabled = true;
                cBoxKasa.Enabled = true;
                cBoxDegisen.Enabled = true;
                cBoxHasarKaydi.Enabled = true;
                txtKilometre.Enabled = true;
                txtFiyat.Enabled = true;
                rtxtAciklama.Enabled = true;
                btnResimSec.Visible = true;
                btnGuncelle.Visible = true;
            }
            else
            {
                txtMarka.Enabled = false;
                txtModel.Enabled = false;
                cBoxMotorHacmi.Enabled = false;
                cBoxSanziman.Enabled = false;
                cBoxDurum.Enabled = false;
                cBoxYakit.Enabled = false;
                cBoxKasa.Enabled = false;
                cBoxDegisen.Enabled = false;
                cBoxHasarKaydi.Enabled = false;
                txtKilometre.Enabled = false;
                txtFiyat.Enabled = false;
                rtxtAciklama.Enabled = false;
                btnResimSec.Visible = false;
                btnGuncelle.Visible = false;
            }
            KutulariDoldur();
        }
        private void KutulariDoldur()
        {
            string commandStr = $"SELECT * FROM Arac_ilanlar WHERE Ilan_id = {Form_Anasayfa.ilanID}";

            SqlDataReader reader = database.Reader(commandStr);

            while (reader.Read())
            {
                txtIlanId.Text = reader[0].ToString();
                txtIlanSahibi.Text = reader[1].ToString();
                txtMarka.Text = reader[2].ToString();
                txtModel.Text = reader[3].ToString();
                cBoxMotorHacmi.Text = reader[4].ToString();
                cBoxSanziman.Text = reader[5].ToString();
                cBoxDurum.Text = reader[6].ToString();
                cBoxYakit.Text = reader[7].ToString();
                cBoxKasa.Text = reader[8].ToString();
                cBoxDegisen.Text = reader[9].ToString();
                cBoxHasarKaydi.Text = reader[10].ToString();
                txtKilometre.Text = reader[11].ToString();
                txtFiyat.Text = reader[12].ToString();
                rtxtAciklama.Text = reader[13].ToString();
                pBoxResim.Image = ByteArrayToImage((byte[])reader[14]);
            }
            database.Disconnect();

            commandStr = $"SELECT * FROM Kullanicilar WHERE Kullanici_adi = '{txtIlanSahibi.Text}'";

            reader = database.Reader(commandStr);

            while (reader.Read())
            {
                txtAd.Text = reader[1].ToString();
                txtSoyad.Text = reader[2].ToString();
                txtTelefonNo.Text = reader[5].ToString();
            }
            database.Disconnect();
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            oFileDialogResim.Title = "Arabanızın fotoğrafını seçiniz";
            oFileDialogResim.FileName = "Dosya seç";
            oFileDialogResim.Filter = "Jpg Dosyaları (*.jpg)|*.jpg|Png Dosyaları (*.png)|*.png|Jpeg Dosyaları (*.jpeg)|*.jpeg";

            if (oFileDialogResim.ShowDialog() == DialogResult.OK)
            {
                pBoxResim.Load(oFileDialogResim.FileName);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Arac_ilan ilan = new Arac_ilan();
            rtxtAciklama.Focus();


            ilan.IlanID = Convert.ToInt32(txtIlanId.Text);
            ilan.IlanSahibi = txtIlanSahibi.Text;
            ilan.Kilometre = Convert.ToInt32(txtKilometre.Text);
            ilan.Fiyat = Convert.ToInt32(txtFiyat.Text);
            ilan.MotorHacmi = cBoxMotorHacmi.Text;
            ilan.Marka = txtMarka.Text;
            ilan.Model = txtModel.Text;
            ilan.Durum = cBoxDurum.Text;
            ilan.Yakit = cBoxYakit.Text;
            ilan.Kasa = cBoxKasa.Text;
            ilan.Sanziman = cBoxSanziman.Text;
            ilan.Degisen = cBoxDegisen.Text;
            ilan.HasarKaydi = cBoxHasarKaydi.Text;
            ilan.Aciklama = rtxtAciklama.Text;

            if (ilan.Ilankontrol())
            {
                // ilan database'e eklenecek resim update edilecek

                string commandStr = $"UPDATE Arac_ilanlar SET " +
                 $"Marka = '{ilan.Marka}', " +
                 $"Model = '{ilan.Model}', " +
                 $"Motor_hacmi = '{ilan.MotorHacmi}', " +
                 $"Sanziman = '{ilan.Sanziman}', " +
                 $"Durum = '{ilan.Durum}', " +
                 $"Yakit = '{ilan.Yakit}', " +
                 $"Kasa = '{ilan.Kasa}', " +
                 $"Degisen = '{ilan.Degisen}', " +
                 $"Hasar_kaydi = '{ilan.HasarKaydi}', " +
                 $"Kilometre = {ilan.Kilometre}, " +
                 $"Fiyat = {ilan.Fiyat}, " +
                 $"Aciklama = '{ilan.Aciklama}' " +
                 $"WHERE Ilan_id = '{ilan.IlanID}'";

                database.Add_Update_Delete(commandStr); // Arac özellikleri güncellendi

                database.ImageUpdate(ImageToByteArray(pBoxResim.Image), ilan.IlanID); // Aracın resmi güncellendi

                DialogResult result = MessageBox.Show("İlanınız başarıyla kaydedildi", "Güncelleme işlemi başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    checkbtnGuncelle.Checked = false;
                    KutulariDoldur();
                }
            }
            else
            {
                MessageBox.Show("Resim ve Açıklama alanları dışındaki alanlar boş bırakılamaz", "Boş alan bıraktınız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkBtnIlanKaldir_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBtnIlanKaldir.Checked)
            {
                DialogResult result = MessageBox.Show("İlanınızı kaldırmak istediğinizden emin misiniz?", "Emin misin?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (DialogResult.Yes == result)
                {
                    string commandStr = $"DELETE FROM Arac_ilanlar WHERE Ilan_id = {Convert.ToInt32(txtIlanId.Text)}";
                    database.Add_Update_Delete(commandStr);

                    MessageBox.Show("İlanınız başarıyla kaldırılmıştır", "İlan silme işlemi başarılı", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    
                    this.Hide();
                    anasayfa.Show();
                }
                else
                {
                    checkBtnIlanKaldir.Checked = false;
                }
            }
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            // byte dizisi tipinde aldığı değişkeni image formatına çeviriyor
            var memoryStream = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(memoryStream);
            return returnImage;
        }
        public static byte[] ImageToByteArray(Image imageIn)
        {
            // Image dosyasını veri tabanında byte dizisi olarak kaydedeceğimizden byte dizisine çeviriyor.
            var memoryStream = new MemoryStream();
            imageIn.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            return memoryStream.ToArray();
        }
    }
}
