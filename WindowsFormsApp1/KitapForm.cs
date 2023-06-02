using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Entity;
using Facade;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class KitapForm : Form
    {
        public KitapForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CrudKitap.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kitap kitap = new Kitap();
            kitap.KitapAd = textBox1.Text;
            kitap.Yazar = textBox2.Text;
            kitap.Turu = textBox4.Text;
            kitap.RafKodu = textBox3.Text;
            kitap.BaskiYili = textBox8.Text;
            kitap.Sayfa = textBox7.Text;
            kitap.Yayinevi = textBox6.Text;
            kitap.Dil = textBox5.Text;
            if (BKitap.Yurut(kitap)==true)
            {
                MessageBox.Show("Başarılı");
            }
            else
            {
                MessageBox.Show("Başarısız");

            }

            dataGridView1.DataSource = CrudKitap.Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kitap kitap = new Kitap();
            kitap.KitapNo = Convert.ToInt32(textBox1.Tag);
            kitap.KitapAd = textBox1.Text;
            kitap.Yazar = textBox2.Text;
            kitap.Turu = textBox4.Text;
            kitap.RafKodu = textBox3.Text;
            kitap.BaskiYili = textBox8.Text;
            kitap.Sayfa = textBox7.Text;
            kitap.Yayinevi = textBox6.Text;
            kitap.Dil = textBox5.Text;
            if (!CrudKitap.Guncelle(kitap))
            {
                MessageBox.Show("Başarısız");
            }
            dataGridView1.DataSource = CrudKitap.Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kitap kitap = new Kitap();
            kitap.KitapNo = Convert.ToInt32(textBox1.Tag);
            if (!CrudKitap.Sil(kitap))
            {
                MessageBox.Show("Başarısız");
            }
            dataGridView1.DataSource = CrudKitap.Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells["KitapNo"].Value.ToString();
            textBox1.Text = row.Cells["KitapAd"].Value.ToString();
            textBox2.Text = row.Cells["Yazar"].Value.ToString();
            textBox4.Text = row.Cells["Turu"].Value.ToString();
            textBox3.Text = row.Cells["RafKodu"].Value.ToString();
            textBox8.Text = row.Cells["BaskiYili"].Value.ToString();
            textBox7.Text = row.Cells["Sayfa"].Value.ToString();
            textBox6.Text = row.Cells["Yayinevi"].Value.ToString();
            textBox5.Text = row.Cells["Dil"].Value.ToString();
        }
        SqlConnection con = new SqlConnection("Server=DESKTOP-76I04D2\\SQLEXPRESS;Database=AKütüphane;Integrated Security=true");

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "KAra";


                    cmd.Parameters.AddWithValue("KitapAd", textBox1.Text);

                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    DataTable doldur = new DataTable();
                    dr.Fill(doldur);
                    dataGridView1.DataSource = doldur;

                }

            }
            catch (Exception Hata)
            {
                MessageBox.Show("Bir hata oluştu!", Hata.Message);
            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaMenu ana = new AnaMenu();
            ana.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AnaMenu ana = new AnaMenu();
            ana.Show();
            this.Hide();
        }
    }
}
