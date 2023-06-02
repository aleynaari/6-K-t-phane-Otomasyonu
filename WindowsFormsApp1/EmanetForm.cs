using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Facade;
using Business;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class EmanetForm : Form
    {
        public EmanetForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CrudVerilenK.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerilenKitap emanet = new VerilenKitap();
            emanet.UNo = Convert.ToInt32(textBox1.Text);
            emanet.KNo = Convert.ToInt32(textBox2.Text);
            emanet.KisiAd = textBox4.Text;
            emanet.KitapAd = textBox3.Text;
            emanet.RafKodu = textBox8.Text;
            emanet.VerilisT = Convert.ToDateTime(dateTimePicker1.Text);
            emanet.İadeT = Convert.ToDateTime(dateTimePicker2.Text);
            emanet.KitapDurumu = textBox7.Text;
            if (!CrudVerilenK.Ekle(emanet))
            {
                MessageBox.Show("Başarısız");
            }
            
            dataGridView1.DataSource = CrudVerilenK.Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerilenKitap emanet = new VerilenKitap();
            emanet.İslemNo = Convert.ToInt32(textBox1.Tag);
            emanet.UNo = Convert.ToInt32(textBox1.Text);
            emanet.KNo = Convert.ToInt32(textBox2.Text);
            emanet.KisiAd = textBox4.Text;
            emanet.KitapAd = textBox3.Text;
            emanet.RafKodu = textBox8.Text;
            emanet.VerilisT =Convert.ToDateTime(dateTimePicker1.Text);
            emanet.İadeT =Convert.ToDateTime(dateTimePicker2.Text);
            emanet.KitapDurumu = textBox7.Text;
            if (!CrudVerilenK.Guncelle(emanet))
            {
                MessageBox.Show("Başarısız");
            }
            dataGridView1.DataSource = CrudVerilenK.Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VerilenKitap emanet = new VerilenKitap();
            emanet.İslemNo = Convert.ToInt32(textBox1.Tag);
            if (!CrudVerilenK.Sil(emanet))
            {
                MessageBox.Show("Başarısız");
            }
            dataGridView1.DataSource = CrudVerilenK.Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells["İslemNo"].Value.ToString();
            textBox1.Text = row.Cells["UNo"].Value.ToString();
            textBox2.Text = row.Cells["KNo"].Value.ToString();
            textBox4.Text = row.Cells["KisiAd"].Value.ToString();
            textBox3.Text = row.Cells["KitapAd"].Value.ToString();
            textBox8.Text = row.Cells["RafKodu"].Value.ToString();
            dateTimePicker1.Text = row.Cells["VerilisT"].Value.ToString();
            dateTimePicker2.Text = row.Cells["İadeT"].Value.ToString();
            textBox7.Text = row.Cells["KitapDurumu"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaMenu ana = new AnaMenu();
            ana.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AnaMenu ana = new AnaMenu();
            ana.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection("Server=DESKTOP-76I04D2\\SQLEXPRESS;Database=AKütüphane;Integrated Security=true");
        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "VAra";


                    cmd.Parameters.AddWithValue("KisiAd", textBox4.Text);

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
