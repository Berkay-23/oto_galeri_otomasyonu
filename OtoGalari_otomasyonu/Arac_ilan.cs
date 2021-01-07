using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGalari_otomasyonu
{
    class Arac_ilan
    {   
        private int _ilanID { get; set; } 
        private int _kilometre { get; set; } 
        private int _fiyat { get; set; } 
        private string _motorHacmi { get; set; }
        private string _marka { get; set; }
        private string _model { get; set; }
        private string _durum { get; set; }
        private string _yakit { get; set; }
        private string _kasa { get; set; }
        private string _sanziman { get; set; }
        private string _degisen { get; set; }
        private string _hasarKaydi { get; set; }
        public string IlanSahibi { get; set; }
        public string Aciklama { get; set; }

        private int gecerlilikDurumu = 0;

        public int IlanID
        {
            get 
            {
                return _ilanID;
            }
            set
            {
                _ilanID = value;
            }
        }
        public int Kilometre
        {
            get
            {
                return _kilometre;
            }
            set
            {
                if (value >= 0) // uzunluk birimi negatif değer almıyacağından sadece pozitif sayılar ve 0 rakamı set edilebilecek
                {
                    _kilometre = value;
                    gecerlilikDurumu += 1;
                }
            }
        }
        public int Fiyat
        {
            get
            {
                return _fiyat;
            }
            set
            {
                if (value >= 0) // fiyat birimi negatif değer almıyacağından sadece pozitif sayılar set edilebilecek
                {
                    _fiyat = value;
                    gecerlilikDurumu += 1;
                }
                else
                {
                    _fiyat = Math.Abs(value);
                    gecerlilikDurumu += 1;
                }
            }
        }
        public string MotorHacmi
        {
            get
            {
                return _motorHacmi;
            }
            set
            {
                if (!value.Equals("Seçiniz"))
                {
                    _motorHacmi = value;
                    gecerlilikDurumu += 1;
                }
            }
        }
        public string Marka
        {
            get
            {
                return _marka;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _marka = value.Trim();
                    gecerlilikDurumu += 1;
                }
            }
        }
        public string Model
        {
            get
            {
                return _model.Trim();
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _model = value;
                    gecerlilikDurumu += 1;
                }
            }
        }
        public string Durum
        {
            get
            {
                return _durum;
            }
            set
            {
                if (!value.Equals("Seçiniz"))
                {
                    _durum = value;
                    gecerlilikDurumu += 1;
                }
            }
        }
        public string Yakit
        {
            get
            {
                return _yakit;
            }
            set
            {
                if (!value.Equals("Seçiniz"))
                {
                    _yakit = value;
                    gecerlilikDurumu += 1;
                }
            }
        }
        public string Kasa
        {
            get
            {
                return _kasa;
            }
            set
            {
                if (!value.Equals("Seçiniz"))
                {
                    _kasa = value;
                    gecerlilikDurumu += 1;
                }
            }
        }
        public string Sanziman
        {
            get
            {
                return _sanziman;
            }
            set
            {
                if (!value.Equals("Seçiniz"))
                {
                    _sanziman = value;
                    gecerlilikDurumu += 1;
                }
            }
        }
        public string Degisen
        {
            get
            {
                return _degisen;
            }
            set
            {
                if (!value.Equals("Seçiniz"))
                {
                    _degisen = value;
                    gecerlilikDurumu += 1;
                }
            }
        }
        public string HasarKaydi
        {
            get
            {
                return _hasarKaydi;
            }
            set
            {
                if (!value.Equals("Seçiniz"))
                {
                    _hasarKaydi = value;
                    gecerlilikDurumu += 1;
                }
            }
        }
        public bool Ilankontrol()
        {
            // Bütün özelliklerin atama işlemini başarıyla sağlanıp sağlanmadığını kontrol eden metod

            if (gecerlilikDurumu == 11)
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
    }
}
