using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Kitap
    {
        private int _KitapNo;
        private string _KitapAd;
        private string _Yazar;
        private string _Turu;
        private string _RafKodu;
        private string _Baskiyili;
        private string _Sayfa;
        private string _Yayinevi;
        private string _Dil;


        public int KitapNo
        {
            get { return _KitapNo; }
            set { _KitapNo = value; }
        }
        public string KitapAd
        {
            get { return _KitapAd; }
            set { _KitapAd = value; }
        }
        public string Yazar
        {
            get { return _Yazar; }
            set { _Yazar = value; }
        }
        public string Turu
        {
            get { return _Turu; }
            set { _Turu = value; }
        }
        public string RafKodu
        {
            get { return _RafKodu; }
            set { _RafKodu = value; }
        }

        public string BaskiYili 
        {
            get { return _Baskiyili; }
            set { _Baskiyili = value; }
        }
        public string Sayfa
        {
            get { return _Sayfa; }
            set { _Sayfa = value; }
        }
        public string Yayinevi
        {
            get { return _Yayinevi; }
            set { _Yayinevi = value; }
        }
        public string Dil
        {
            get { return _Dil; }
            set { _Dil = value; }
        }
    }
}
