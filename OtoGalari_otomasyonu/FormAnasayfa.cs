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
using System.IO;

namespace OtoGalari_otomasyonu
{
    public partial class Form_Anasayfa : Form
    {
        Form_Giris giris = new Form_Giris();
        SqlDatabase database = new SqlDatabase();

        Panel panel;
        PictureBox pictureBox;
        Label label;

        public static int ilanID;

        string dinamikSorgu = "SELECT * FROM Arac_ilanlar"; // length = 25
        public Form_Anasayfa()
        {
            InitializeComponent();
        }

        private void Form_Anasayfa_Load(object sender, EventArgs e)
        {
            IlanlariYerlestir("SELECT * FROM Arac_ilanlar ORDER BY Ilan_id");
        }

        private void IlanlariYerlestir(string commandStr)
        {
            pnlIlanlar.Controls.Clear();

            SqlDataReader reader = database.Reader(commandStr);

            int i = 0;

            while (reader.Read())
            {
                try
                {
                    // Panel ekle fonksiyonuna iki panel arası uzaklık ve panelin etiketini gönderiyoruz.
                    PanelEkle(i, reader[0].ToString());

                    // Labellara içide yazılacak yazıyı, x ve y koordinatlarını gönderiyoruz.
                    LabelEkle(reader[2].ToString() + " " + reader[3].ToString(), 115, 15); // Marka + Model yazdırılacak
                    LabelEkle(reader[5].ToString(), 115, 65); // Şanzıman yazdırılacak
                    LabelEkle(reader[6].ToString(), 115, 40); // Aracın Durumu yazdırılacak
                    LabelEkle(BasamakAyir(Convert.ToInt32(reader[11])) + " km", 250, 40); // Aracın kilometre bilgisini yazdıracak 
                    LabelEkle(BasamakAyir(Convert.ToInt32(reader[12])) + " ₺", 250, 65); // Aracın fiyat bilgisini yazdıracak

                    // Picturebox'a databaseden gelen byte dizisi halindeki resimi Image formatına çevirerek yolluyoruz.
                    PictureBoxEkle(ByteArrayToImage((byte[])reader[14]));

                    i = i + 1;

                }
                catch(Exception excp)
                {
                    DialogResult result = MessageBox.Show(excp.Message, "Hay Aksi Hatayla karşılaşıldı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        Application.Restart();
                    }
                }
            }
            database.Disconnect();

            if (i == 0) // Hiçbir sonuç bulunamamıştır
            {
                label = new Label();
                label.Text = "SONUÇ BULUNAMADI";
                label.AutoSize = true;
                label.Location = new Point(12, 50);
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.White;
                label.Font = new System.Drawing.Font("Yu Gothic UI", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                pnlIlanlar.Controls.Add(label);
            }
        }

        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            // İlan'a tıklandığında araç bilgilerini gösterecek

            Form_Ilan ilan = new Form_Ilan();

            ilanID = Convert.ToInt32(((Panel)sender).Tag);

            this.Hide();
            ilan.Show();
        }

        private void Panel_MouseHover(object sender, EventArgs e)
        {
            //Mouse ilanın üzerine geldiğinde arkaplanı Crimson yapıyor.
            ((Panel)sender).BackColor = Color.Crimson;
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            //Mouse ilanın üzerinden ayrıldığında arkaplanı eski rengine (gri) çeviriyor.
            ((Panel)sender).BackColor = Color.DarkSlateGray;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            giris.Show();
        }

        private void btnIlanEkle_Click(object sender, EventArgs e)
        {
            Form_Ilan_Ekleme ilanEkleme = new Form_Ilan_Ekleme();
            this.Hide();
            ilanEkleme.Show();
        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            // byte dizisi tipinde aldığı değişkeni image formatına çeviriyor
            var memoryStream = new MemoryStream(byteArrayIn);
            Image returnImage = null;

            try
            {
                returnImage = Image.FromStream(memoryStream);
            }
            catch (Exception excp)
            {
                DialogResult result = MessageBox.Show(excp.Message, "Hay Aksi Hatayla karşılaşıldı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (DialogResult.OK == result)
                {
                    Application.Restart();
                }
                
            }
            return returnImage;
        }
        private string BasamakAyir(int sayi) // İlan üzerindeki kilometre ve fiyat bilgilerini noktayla ayırıyor
        {
            string str = sayi.ToString();

            int ayirmaIndexi = str.Length - 3;

            while (ayirmaIndexi > 0)
            {
                string parca1 = str.Substring(0, ayirmaIndexi);
                string parca2 = str.Substring(ayirmaIndexi);

                str = parca1 + "." + parca2;
                ayirmaIndexi = ayirmaIndexi - 3;
            }
            return str;
        }
        private void PanelEkle(int i, string tag) // Her ilan için ilanlar paneline yeni bir panel ekliyor
        {
            panel = new Panel();
            panel.Size = new Size(375, 100);
            panel.Location = new Point(5, 5 + (i * 105));
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

        private void btnHesabim_Click(object sender, EventArgs e)
        {
            Form_Hesap hesap = new Form_Hesap();
            this.Hide();
            hesap.Show();
        }
        private void btnSorgula_Click(object sender, EventArgs e)
        {
            //fiyat kontrolü yapan metod yaz

            btnFiltreSıfirla.Focus();
            MaxMinKontrolEt();

            dinamikSorgu = dinamikSorgu + ")";

            string sorgu = SorguDuzenle(dinamikSorgu) + " ORDER BY Ilan_id";

            if (dinamikSorgu.Contains("Fiyat"))
            {
                dinamikSorgu = dinamikSorgu.Substring(0, (dinamikSorgu.IndexOf("Fiyat") - 7));
                dinamikSorgu += ")";
            }

            dinamikSorgu = dinamikSorgu.Remove(dinamikSorgu.Length-1);
            IlanlariYerlestir(sorgu);
        }
        private void MaxMinKontrolEt()
        {
            bool minGirilmisMi = false, maxGirilmisMi = false;

            if (!txtMaxFiyat.Text.Equals("Max"))
            {
                maxGirilmisMi = true;
            }
            if (!txtMinFiyat.Text.Equals("Min"))
            {
                minGirilmisMi = true;
            }

            if (minGirilmisMi == true && maxGirilmisMi == true)
            {
                dinamikSorgu += $") AND (Fiyat >= {Convert.ToInt32(txtMinFiyat.Text)} AND Fiyat <= {Convert.ToInt32(txtMaxFiyat.Text)} OR ";
            }
            else if (minGirilmisMi == false && maxGirilmisMi == true)
            {
                dinamikSorgu += $") AND (Fiyat <= {Convert.ToInt32(txtMaxFiyat.Text)} OR ";
            }
            else if (minGirilmisMi == true && maxGirilmisMi == false)
            {
                dinamikSorgu += $") AND (Fiyat >= {Convert.ToInt32(txtMinFiyat.Text)} OR ";
            }

        }
        private void btnFiltreSıfirla_Click(object sender, EventArgs e) // bütün işaretlemeler kaldırılıyor
        {
            checkSifir.Checked = false;
            checkIkinciEl.Checked = false;
            checkManuel.Checked = false;
            checkOtomatik.Checked = false;
            checkYariOtomatik.Checked = false;
            checkCabrio.Checked = false;
            checkCoupe.Checked = false;
            checkSedan.Checked = false;
            checkHatchback.Checked = false;
            checkStationWagon.Checked = false;
            checkCrossover.Checked = false;
            checkMinivan.Checked = false;
            checkBenzin.Checked = false;
            checkDizel.Checked = false;
            checkHybrid.Checked = false;
            checkElektrik.Checked = false;
            check1_3Motor.Checked = false;
            check1_6Motor.Checked = false;
            check1_8Motor.Checked = false;
            check2_0Motor.Checked = false;
            check2_5Motor.Checked = false;
            check3_0Motor.Checked = false;

            txtMinFiyat.Text = "Min";
            txtMaxFiyat.Text = "Max";

            btnSorgula_Click(sender, e);
        }

        // ***** Filitreleme panelindeki checkboxlar işaretlenince dinamik dinamikSorgu oluşturan metoda kendi verilerini gönderiyor ***** //
        private void checkSifir_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkSifir, "Durum", checkSifir.Text, ref durumTikSayisi);
        }

        private void checkIkinciEl_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkIkinciEl, "Durum", checkIkinciEl.Text, ref durumTikSayisi);
        }

        private void checkManuel_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkManuel, "Sanziman", checkManuel.Text, ref sanzimanTikSayisi);
        }

        private void checkOtomatik_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkOtomatik, "Sanziman", checkOtomatik.Text, ref sanzimanTikSayisi);
        }

        private void checkYariOtomatik_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkYariOtomatik, "Sanziman", checkYariOtomatik.Text, ref sanzimanTikSayisi);
        }

        private void checkCabrio_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkCabrio, "Kasa", checkCabrio.Text, ref kasaTikSayisi);
        }

        private void checkCoupe_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkCoupe, "Kasa", checkCoupe.Text, ref kasaTikSayisi);
        }

        private void checkSedan_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkSedan, "Kasa", checkSedan.Text, ref kasaTikSayisi);
        }

        private void checkHatchback_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkHatchback, "Kasa", checkHatchback.Text, ref kasaTikSayisi);
        }

        private void checkStationWagon_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkStationWagon, "Kasa", checkStationWagon.Text, ref kasaTikSayisi);
        }

        private void checkCrossover_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkCrossover, "Kasa", checkCrossover.Text, ref kasaTikSayisi);
        }

        private void checkMinivan_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkMinivan, "Kasa", checkMinivan.Text, ref kasaTikSayisi);
        }

        private void checkBenzin_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkBenzin, "Yakit", checkBenzin.Text, ref yakitTikSayisi);
        }

        private void checkDizel_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkDizel, "Yakit", checkDizel.Text, ref yakitTikSayisi);
        }

        private void checkHybrid_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkHybrid, "Yakit", checkHybrid.Text, ref yakitTikSayisi);
        }

        private void checkElektrik_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(checkElektrik, "Yakit", checkElektrik.Text, ref yakitTikSayisi);
        }

        private void check1_3Motor_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(check1_3Motor, "Motor_hacmi", check1_3Motor.Text, ref motorTikSayisi);
        }

        private void check1_6Motor_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(check1_6Motor, "Motor_hacmi", check1_6Motor.Text, ref motorTikSayisi);
        }

        private void check1_8Motor_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(check1_8Motor, "Motor_hacmi", check1_8Motor.Text, ref motorTikSayisi);
        }

        private void check2_0Motor_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(check2_0Motor, "Motor_hacmi", check2_0Motor.Text, ref motorTikSayisi);
        }

        private void check2_5Motor_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(check2_5Motor, "Motor_hacmi", check2_5Motor.Text, ref motorTikSayisi);
        }

        private void check3_0Motor_CheckedChanged(object sender, EventArgs e)
        {
            SorguYaz(check3_0Motor, "Motor_hacmi", check3_0Motor.Text, ref motorTikSayisi);
        }
        // ***** dinamik dinamikSorgu oluştruma işlemleri burada sonlanıyor ***** //

        int durumTikSayisi = 0, sanzimanTikSayisi = 0, kasaTikSayisi = 0, yakitTikSayisi = 0, motorTikSayisi = 0;

        private void txtMinFiyat_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMinFiyat.Text == "0")
            {
                txtMinFiyat.Text = "Min";
            }
        }

        private void txtMaxFiyat_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMaxFiyat.Text == "0")
            {
                txtMaxFiyat.Text = "Max";
            }
        }

        private void IsaretSayisiKontrol(int sayi) // Kategorilerin tikli özellik sayısı kontrol ediliyor
        {
            if (sayi == 1)
            {
                dinamikSorgu = dinamikSorgu + ") AND (";
            }
        }

        private void SorguYaz(DevExpress.XtraEditors.CheckEdit checkBox, string kategori, string text, ref int isaretSayisi)
        {
            // Checkboxlar işaretlenince verileri bu metoda gönderiliyor ve dinamik sorgumuz güncelleniyor. 

            if (checkBox.Checked) // işaretleme olunca sorguya ekleme yapılıyor ve işaret sayısı artıyor
            {
                isaretSayisi++;
                IsaretSayisiKontrol(isaretSayisi);

                /* normalde en son işaretlenen checkbox sorguda en sona geliyor ancak katgorileri aynı olanlar aynı parantez içinde olması gerektiğinden 
                önce o katagori dinamikSorgu içinde var mı kontrol edilecek eğer varsa o parantez içinde saptanan indexten itibaren yazılacak 
                eğer kategorisi yoksa en sona yazılmaya devam edecek.
                 */

                if (dinamikSorgu.Contains(kategori))
                {
                    int indexKategori = dinamikSorgu.IndexOf(kategori);
                    string p1 = dinamikSorgu.Substring(0, indexKategori);
                    string p2 = dinamikSorgu.Substring(indexKategori);

                    dinamikSorgu = p1 + $"{kategori} = '{text}' OR " + p2;
                }
                else
                {
                    dinamikSorgu = dinamikSorgu + $"{kategori} = '{text}' OR ";
                }
            }
            else // işaretleme kalkınca sorgudan sorgudan eklenen string ifade siliniyor ve işaret sayısı azalıyor
            {
                isaretSayisi--;
                dinamikSorgu = dinamikSorgu.Replace($"{kategori} = '{text}' OR ", "");

                if (isaretSayisi == 0)
                {
                    // Bir kategori kaldırıldığında o kategöri için açılan ve kapanan parantezlerin silinmesi gerekiyor bu blokta bunun kontrolü ve silinmesi sağlanıyor

                    int indexParantez = dinamikSorgu.LastIndexOf(") AND ()"); // eğer kaldırılan kategori başta ya da ortalardaysa pozitif değer döner

                    if (indexParantez == -1)
                    {
                        indexParantez = dinamikSorgu.Length - 7;
                    }

                    // silinecek ifadenin öncesi ve sonrası birleştirilip dinamikSorgu yenileniyor
                    string p1 = dinamikSorgu.Substring(0, indexParantez);
                    string p2 = dinamikSorgu.Substring(indexParantez + 7);
                    dinamikSorgu = p1 + p2;
                }
            }
        }
        private string SorguDuzenle(string str) // Bu fonksiyon dinamik olan sorgumuzdaki fazla yazılan AND ve OR stringlerini siliyor
        {
            int index = 0;
            string sonuc;

            if (str.Length != 27)
            {
                string s1 = str.Substring(0, 26);
                string s2 = str.Substring(26);

                str = s1 + " WHERE " + s2;

                str = str.Remove(32, 6); // [32,38] aralığında ") AND (" ifadesini siliyor 

                sonuc = str;

                foreach (char character in str)
                {
                    if (character == ')')
                    {
                        string p1 = sonuc.Substring(0, (index - 4));
                        string p2 = sonuc.Substring(index);
                        sonuc = p1 + p2;
                        // İfadeden bir parça sildiğimiz için length değişecek ve ilerleyen durumlarda hatalı veri silmemek için sildiğimiz parçanın uzunluğu kadar indexi azaltıyoruz
                        index = index - 4; // " OR " Length = 4 (boşluklar dahil)
                    }
                    index += 1;
                }
            }
            else
            {
                sonuc = "SELECT * FROM Arac_ilanlar";
            }

            return sonuc;
        }
    }
}
