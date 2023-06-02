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
using Facade;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{

    public partial class UyeForm : Form
    {
        public UyeForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CrudUye.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uye uye = new Uye();
            uye.AdSoyad = textBox1.Text;
            uye.Mail = textBox2.Text;
            uye.Adres = textBox4.Text;
            uye.Tel = textBox3.Text;
            if (!CrudUye.Ekle(uye))
            {
                MessageBox.Show("Başarısız");
            }
            dataGridView1.DataSource = CrudUye.Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Uye uye = new Uye();
            uye.UyeNo = Convert.ToInt32(textBox1.Tag);
            uye.AdSoyad = textBox1.Text;
            uye.Mail = textBox2.Text;
            uye.Adres = textBox4.Text;
            uye.Tel = textBox3.Text;
            if (!CrudUye.Guncelle(uye))
            {
                MessageBox.Show("Başarısız");
            }
            dataGridView1.DataSource = CrudUye.Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Uye uye = new Uye();
            uye.UyeNo = Convert.ToInt32(textBox1.Tag);
            if (!CrudUye.Sil(uye))
            {
                MessageBox.Show("Başarısız");
            }
            dataGridView1.DataSource = CrudUye.Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells["UyeNo"].Value.ToString();
            textBox1.Text = row.Cells["AdSoyad"].Value.ToString();
            textBox2.Text = row.Cells["Mail"].Value.ToString();
            textBox4.Text = row.Cells["Adres"].Value.ToString();
            textBox3.Text = row.Cells["Tel"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaMenu ana = new AnaMenu();
            ana.Show();
            this.Hide();
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
                    cmd.CommandText = "UAra";


                    cmd.Parameters.AddWithValue("AdSoyad", textBox1.Text);

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
    }
}
