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
    public class CrudKullanici
    {
        public static bool Ekle(Kullanici kullanici)
        {
            SqlCommand komut = new SqlCommand("KullaniciEkle", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("KullaniciAd", kullanici.KullaniciAd);
            komut.Parameters.AddWithValue("Sifre", kullanici.Sifre);
            komut.Parameters.AddWithValue("AdSoyad", kullanici.AdSoyad);
            return DBaglanti.exec(komut);
        }
    }
}
