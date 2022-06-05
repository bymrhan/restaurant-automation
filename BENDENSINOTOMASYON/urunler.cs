using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BENDENSINOTOMASYON
{
    public partial class urunler : Form
    {
        static string baglantiyolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=restorandb.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiyolu);
        public urunler()
        {
            InitializeComponent();
        }

        private void urunler_Load(object sender, EventArgs e)
        {
            listele();           
        }

        private void btnicecek_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select *From urun where kategori=2", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btnanayemek_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select *From urun where kategori=3", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btncorbalar_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select *From urun where kategori=8", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btnsalatalar_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select *From urun where kategori=1", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btntatlilar_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select *From urun where kategori=7", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btnhamburger_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select *From urun where kategori=6", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btnpizzalar_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select *From urun where kategori=5", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btnkahvalti_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select *From urun where kategori=4", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btnurunsil_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                string secilenid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                komut.CommandText = "Delete from urun where urunid=" + secilenid + "";
                DataSet ds = new DataSet();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                ds.Clear();

                listele();
            }

            }

        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From urun", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnurunsil.Enabled = true;
            btnurunguncelle.Enabled = true;
            btnurunekle.Enabled = false;
        }

        private void btnurunguncelle_Click(object sender, EventArgs e)
        {
            //urunguncelle butonuna basıldığında urukleye bir id gönderiyoruz bu id ilk başta null olarak belirlenmiştir.
            urunekle fr = new urunekle();
            fr.gelenid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            fr.ShowDialog();
        }

        private void btnurunekle_Click(object sender, EventArgs e)
        {
            Form frm = new urunekle();
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
