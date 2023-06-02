using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Facade;

namespace Business
{
    public class BKitap
    {
        public static bool Yurut(Kitap kitap)
        {
            if (kitap.KitapAd != null && kitap.KitapAd.Trim().Length > 0)
            {
                return CrudKitap.Ekle(kitap);
            }
            return true; 
        }
    }
}
