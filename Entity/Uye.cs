using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Uye
    {
        private int _UyeNo;
        private string _AdSoyad;
        private string _Mail;
        private string _Adres;
        private string _Tel;


        public int UyeNo
        {
            get { return _UyeNo; }
            set { _UyeNo = value; }
        }

        public string AdSoyad
        {
            get { return _AdSoyad; }
            set { _AdSoyad = value; }
        }
        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }
        public string Adres
        {
            get { return _Adres; }
            set { _Adres = value; }
        }

        public string Tel 
        {
            get { return _Tel; }
            set { _Tel = value; }
        }
    }
}
