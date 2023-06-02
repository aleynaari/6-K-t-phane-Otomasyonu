using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Facade
{
    public class CrudVerilenK
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("VListele", DBaglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static bool Ekle(VerilenKitap emanet)
        {
            SqlCommand komut = new SqlCommand("VEkle", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("UNo", emanet.UNo);
            komut.Parameters.AddWithValue("KNo", emanet.KNo);
            komut.Parameters.AddWithValue("KisiAd", emanet.KisiAd);
            komut.Parameters.AddWithValue("KitapAd", emanet.KitapAd);
            komut.Parameters.AddWithValue("RafKodu", emanet.RafKodu);
            komut.Parameters.AddWithValue("VerilisT", emanet.VerilisT);
            komut.Parameters.AddWithValue("İadeT", emanet.İadeT);
            komut.Parameters.AddWithValue("KitapDurumu", emanet.KitapDurumu);
            return DBaglanti.exec(komut);

        }
        public static bool Guncelle(VerilenKitap emanet)
        {
            SqlCommand komut = new SqlCommand("VGuncelle", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("İslemNo", emanet.İslemNo);
            komut.Parameters.AddWithValue("UNo", emanet.UNo);
            komut.Parameters.AddWithValue("KNo", emanet.KNo);
            komut.Parameters.AddWithValue("KisiAd", emanet.KisiAd);
            komut.Parameters.AddWithValue("KitapAd", emanet.KitapAd);
            komut.Parameters.AddWithValue("RafKodu", emanet.RafKodu);
            komut.Parameters.AddWithValue("VerilisT", emanet.VerilisT);
            komut.Parameters.AddWithValue("İadeT", emanet.İadeT);
            komut.Parameters.AddWithValue("KitapDurumu", emanet.KitapDurumu);
            return DBaglanti.exec(komut);
        }
        public static bool Sil(VerilenKitap emanet)
        {
            SqlCommand komut = new SqlCommand("VSil",DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("İslemNo", emanet.İslemNo);
            return DBaglanti.exec(komut);

        }
    }
}
