using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Facade;
using Entity;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //SqlConnection con = new SqlConnection("Server=215-18\\SQLEXPRESS;Database=AKütüphane;uid=SA;pwd=Ibb2022#!;");
        SqlConnection con = new SqlConnection("Server=DESKTOP-76I04D2\\SQLEXPRESS;Database=AKütüphane;Integrated Security=true");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible=true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "Giris";
            cmd.Parameters.AddWithValue("kad", textBox1.Text);
            cmd.Parameters.AddWithValue("sifre", textBox2.Text);

            con.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı Bir Şekilde Giriş Yaptınız.");
                AnaMenu menu = new AnaMenu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adınız veya Şifreniz Hatalı. Kontrol ediniz.");
                textBox1.Clear();
                textBox2.Clear();
            }
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciAd = textBox4.Text;
            kullanici.Sifre = textBox3.Text;
            kullanici.AdSoyad = textBox5.Text;
            if (CrudKullanici.Ekle(kullanici))
            {
                
                AnaMenu menu = new AnaMenu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Başarısız");
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
