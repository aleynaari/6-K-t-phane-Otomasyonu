using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Kullanici
    {
        private string _KullaniciAd;
        private string _Sifre;
        private string _AdSoyad;

        public string KullaniciAd
        {
            get { return _KullaniciAd; }
            set { _KullaniciAd = value; }
        }
        public string Sifre
        {
            get { return _Sifre; }
            set { _Sifre = value; }
        }
        public string AdSoyad
        {
            get { return _AdSoyad; }
            set { _AdSoyad = value; }
        }
    }
}
