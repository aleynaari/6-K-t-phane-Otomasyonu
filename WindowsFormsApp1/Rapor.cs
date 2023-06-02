using Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Entity;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }

        SqlConnection db = new SqlConnection("Server=DESKTOP-76I04D2\\SQLEXPRESS;Database=AKütüphane;Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CrudRapor.S1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlElement root = xmldoc.CreateElement("Kitap");
            SqlCommand cmd = new SqlCommand("select *  from Kitap", db);
            db.Open();
            SqlDataReader dr =cmd.ExecuteReader();
            while (dr.Read())
            {
                XmlElement kitap = xmldoc.CreateElement("KitapBilgi");
                XmlAttribute ad = xmldoc.CreateAttribute("KitapAd");
                ad.Value = dr["KitapAd"].ToString();

                XmlAttribute yazar = xmldoc.CreateAttribute("Yazar");
                yazar.Value = dr["Yazar"].ToString();

                XmlAttribute tur = xmldoc.CreateAttribute("Turu");
                tur.Value = dr["Turu"].ToString();

                XmlAttribute baski = xmldoc.CreateAttribute("BaskiYili");
                baski.Value = dr["BaskiYili"].ToString();

                XmlAttribute sayfa = xmldoc.CreateAttribute("Sayfa");
                sayfa.Value = dr["Sayfa"].ToString();

                kitap.Attributes.Append(ad);
                kitap.Attributes.Append(yazar);
                kitap.Attributes.Append(tur);
                kitap.Attributes.Append(baski);
                kitap.Attributes.Append(sayfa);
                root.AppendChild(kitap);

            }

            db.Close();
            xmldoc.AppendChild(root);
            xmldoc.Save("kitapveri.xml");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaMenu ana = new AnaMenu();
            ana.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CrudRapor.S2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CrudRapor.S3();

        }
    }
}
