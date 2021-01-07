using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OtoGalari_otomasyonu
{
    class Musteri
    {
        private string _kullaniciAdi { get; set; }
        private string _isim { get; set; }
        private string _soyisim { get; set; }
        private string _ePosta { get; set; }
        private string _sifre { get; set; }
        private string _telefonNo { get; set; }

        private int gecerlilikDurumu = 0;
        public string hataKodlari = "?";
        public string KullaniciAdi
        {
            get
            {
                return _kullaniciAdi;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Trim() != "Kullanıcı Adı")
                {
                    _kullaniciAdi = value;
                    gecerlilikDurumu += 1;
                }
                else
                {
                    // Kullanıcı Adı girilmedi
                    Debug.WriteLine("Geçersiz Kullanıcı Adı");
                    Debug.WriteLine(_kullaniciAdi + "\n");
                    hataKodlari += "ka0_";
                }
            }
        }
        public string Isim
        {
            get
            {
                return _isim;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Trim() != "İsim")
                {
                    _isim = value.Trim();
                    gecerlilikDurumu += 1;
                }
                else
                {
                    // İsim girilmedi
                    Debug.WriteLine("Geçersiz İsim");
                    Debug.WriteLine(_isim + "\n");
                    hataKodlari += "i1_";
                }
            }
        }
        public string Soyisim
        {
            get
            {
                return _soyisim;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Trim() != "Soyisim")
                {
                    _soyisim = value.Trim();
                    gecerlilikDurumu += 1;
                }
                else
                {
                    // Soyisim girilmedi
                    Debug.WriteLine("Geçersiz Soyisim");
                    Debug.WriteLine(_soyisim + "\n");
                    hataKodlari += "s2_";
                }
            }
        }

        public string EPosta
        {
            get
            {
                return _ePosta;
            }
            set
            {
                if (value.Contains("@") && value.Contains(".") && value.Length > 9 && !value.Contains(" "))
                {
                    // gelen değer '@' sembolü ,ve '.' işareti içeriyorsa ve uzunluğu 9 dan fazla ve boşluk karakteri içermiyorsa geçerli e-postadır.  
                    _ePosta = value;
                    gecerlilikDurumu += 1;
                }
                else
                {
                    //Geçersiz e-posta
                    Debug.WriteLine("Geçersiz e-posta");
                    Debug.WriteLine(_ePosta + "\n");
                    hataKodlari += "ep3_";
                }
            }
        }
        public string Sifre
        {
            get
            {
                return _sifre;
            }
            set
            {
                // Şifrenin güvenlik kontrolünü yapacak ona göre atama yapcak

                if (SifreGuvenlikKontrolu(value) == true)
                {
                    _sifre = value;
                    gecerlilikDurumu += 1;
                }
                else
                {
                    // Şifre güvenli değil.
                    Debug.WriteLine("Şifreniz güvenli değil yeni şifre oluşturunuz");
                    Debug.WriteLine(_sifre + "\n");
                    hataKodlari += "s4_";
                }
            }
        }
        public string TelefonNo
        {
            get
            {
                return _telefonNo;
            }
            set
            {
                if (value.Length == 10 && value[0] != '0')
                {
                    _telefonNo = "0" + value;
                    gecerlilikDurumu += 1;
                }
                else if (value.Length == 11 && value[0] == '0')
                {
                    _telefonNo = value;
                    gecerlilikDurumu += 1;
                }
                else
                {
                    // Hatalı telefon numarası girilmiştir
                    Debug.WriteLine("Geçersiz Telefon Numarası");
                    Debug.WriteLine(_telefonNo);
                    hataKodlari += "t5_";
                }
            }
        }
        public bool KayitKontrol()
        {
            // Bütün özelliklerin atama işlemini başarıyla sağlanıp sağlanmadığını kontrol eden metod

            if (gecerlilikDurumu == 6)
            {
                gecerlilikDurumu = 0;
                return true;
            }
            else
            {
                gecerlilikDurumu = 0;
                return false;
            }
        }
        
        private bool SifreGuvenlikKontrolu(string sifre) 
        {
            // Girilen şifrenin içerdiği farklı karakterlere göre güvenliğini kontrol eden metod

            string kucukHarfler = "qwertyuıopğüasdfghjklşizxcvbnmöç";
            string buyukHarfler = "QWERTYUIOPĞÜASDFGHJKLŞİZXCVBNMÖÇ";
            string semboller = @"_-.,;:?*/+!&><|()[]{}%#'";
            string rakamlar = "0123456789";

            int guvenlikDuzeyi = 0;

            foreach (char karakter in sifre)
            {
                foreach (char harf in kucukHarfler)
                {
                    if (karakter == harf)
                    {
                        // Şifrede küçük harf bulunuyor
                        guvenlikDuzeyi += 1;
                        goto e1; // şifre içerisinde küçük harfe rastladığı an sıradaki karakter aramasına yönlendiriyor.
                    }
                }
            }

        e1:
            foreach (char karakter in sifre)
            {
                foreach (char harf in buyukHarfler)
                {
                    if (karakter == harf)
                    {
                        // Şifrede büyük harf bulunuyor 
                        guvenlikDuzeyi += 1;
                        goto e2; // şifre içerisinde büyük harfe rastladığı an sıradaki karakter aramasına yönlendiriyor.
                    }
                }
            }

        e2:
            foreach (char karakter in sifre)
            {
                foreach (char sembol in semboller)
                {
                    if (karakter == sembol)
                    {
                        // Şifrede sembol bulunuyor 
                        guvenlikDuzeyi += 1;
                        goto e3; // şifre içerisinde sembole (Ör : _ ! ? ...) rastladığı an sıradaki karakter aramasına yönlendiriyor.
                    }
                }
            }

        e3:
            foreach (char karakter in sifre)
            {
                foreach (char rakam in rakamlar)
                {
                    if (karakter == rakam)
                    {
                        // Şifrede rakam bulunuyor 
                        guvenlikDuzeyi += 1;
                        goto e4; // şifre içerisinde rakama rastladığı an sıradaki şifrenin uzunluk kontrolcülerine yönlendiriyor.
                    }
                }
            }

        e4:
            if (sifre.Length > 10)
            {
                guvenlikDuzeyi += 1;
            }
            else if (sifre.Length < 6)
            {
                // Şifre 6 karakterden kısaysa geçersiz sayılıyor.
                return false;
            }

            if (guvenlikDuzeyi >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
