using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Facade
{
    class DBaglanti
    {
        // public static readonly SqlConnection con = new SqlConnection("Server=215-18\\SQLEXPRESS;Database=AKütüphane;uid=SA;pwd=Ibb2022#!;");

        public static readonly SqlConnection con = new SqlConnection("Server=DESKTOP-76I04D2\\SQLEXPRESS;Database=AKütüphane;Integrated Security=true");

        public static bool exec(SqlCommand komut)
        {
            try
            {
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                    return komut.ExecuteNonQuery() > 0;
                }
            }
            catch 
            {
                return false;
            }
            finally
            {
                if (komut.Connection.State != ConnectionState.Closed)
                {
                    komut.Connection.Close();
                }
            }
            return true;
        }
    }
}
