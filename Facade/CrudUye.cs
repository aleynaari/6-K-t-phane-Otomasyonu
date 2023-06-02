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
    public class CrudUye
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("UListele", DBaglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static bool Ekle(Uye uye)
        {
            SqlCommand komut = new SqlCommand("UEkle", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("AdSoyad", uye.AdSoyad);
            komut.Parameters.AddWithValue("Mail", uye.Mail);
            komut.Parameters.AddWithValue("Adres", uye.Adres);
            komut.Parameters.AddWithValue("Tel", uye.Tel);
            return DBaglanti.exec(komut);

        }

        public static bool Guncelle(Uye uye)
        {
            SqlCommand komut = new SqlCommand("UGuncelle", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("UyeNo", uye.UyeNo);

            komut.Parameters.AddWithValue("AdSoyad", uye.AdSoyad);
            komut.Parameters.AddWithValue("Mail", uye.Mail);
            komut.Parameters.AddWithValue("Adres", uye.Adres);
            komut.Parameters.AddWithValue("Tel", uye.Tel);
            return DBaglanti.exec(komut);

        }

        public static bool Sil(Uye uye)
        {
            SqlCommand komut = new SqlCommand("USil", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("UyeNo", uye.UyeNo);
            return DBaglanti.exec(komut);
        }

    }
}
