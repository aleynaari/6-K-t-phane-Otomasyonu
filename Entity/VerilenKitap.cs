using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class VerilenKitap
    {
        private int _İslemNo;
        private int _UNo;
        private int _KNo;
        private string _KisiAd;
        private string _KitapAd;
        private string _RafKodu;
        private DateTime  _VerilisT;
        private DateTime  _İadeT;
        private string _KitapDurumu;

        public int İslemNo
        {
            get { return _İslemNo; }
            set { _İslemNo = value; }
        }
        public int UNo
        {
            get { return _UNo; }
            set { _UNo = value; }
        }
        public int KNo
        {
            get { return _KNo; }
            set { _KNo = value; }
        }
        public string KisiAd
        {
            get { return _KisiAd; }
            set { _KisiAd = value; }
        }
        public string KitapAd
        {
            get { return _KitapAd; }
            set { _KitapAd = value; }
        }
        public string RafKodu
        {
            get { return _RafKodu; }
            set { _RafKodu = value; }
        }
        public DateTime VerilisT
        {
            get { return _VerilisT; }
            set { _VerilisT = value; }
        }
        public DateTime İadeT
        {
            get { return _İadeT; }
            set { _İadeT = value; }
        }
        public string KitapDurumu
        {
            get { return _KitapDurumu; }
            set { _KitapDurumu = value; }
        }

    }
}
