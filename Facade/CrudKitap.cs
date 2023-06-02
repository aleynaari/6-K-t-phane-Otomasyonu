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
    public class CrudKitap
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("KListele", DBaglanti.con); 
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static bool Ekle(Kitap kitap)
        {
            SqlCommand komut = new SqlCommand("KEkle",DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("KitapAd", kitap.KitapAd);
            komut.Parameters.AddWithValue("Yazar", kitap.Yazar);
            komut.Parameters.AddWithValue("Turu", kitap.Turu);
            komut.Parameters.AddWithValue("RafKodu", kitap.RafKodu);
            komut.Parameters.AddWithValue("BaskiYili", kitap.BaskiYili);
            komut.Parameters.AddWithValue("Sayfa", kitap.Sayfa);
            komut.Parameters.AddWithValue("Yayinevi", kitap.Yayinevi);
            komut.Parameters.AddWithValue("Dil", kitap.Dil);
            return DBaglanti.exec(komut);
        }
        public static bool Guncelle(Kitap kitap)
        {
            SqlCommand komut = new SqlCommand("KGuncelle", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("KitapNo", kitap.KitapNo);
            komut.Parameters.AddWithValue("KitapAd", kitap.KitapAd);
            komut.Parameters.AddWithValue("Yazar", kitap.Yazar);
            komut.Parameters.AddWithValue("Turu", kitap.Turu);
            komut.Parameters.AddWithValue("RafKodu", kitap.RafKodu);
            komut.Parameters.AddWithValue("BaskiYili", kitap.BaskiYili);
            komut.Parameters.AddWithValue("Sayfa", kitap.Sayfa);
            komut.Parameters.AddWithValue("Yayinevi", kitap.Yayinevi);
            komut.Parameters.AddWithValue("Dil", kitap.Dil);
            return DBaglanti.exec(komut);
        }
        public static bool Sil(Kitap kitap)
        {
            SqlCommand komut = new SqlCommand("KSil",DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("KitapNo", kitap.KitapNo);
            return DBaglanti.exec(komut);
        }
    }
}
