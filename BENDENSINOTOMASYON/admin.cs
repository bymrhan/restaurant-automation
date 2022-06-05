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
    public partial class admin : Form
    {
        static string baglantiyolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=restorandb.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiyolu);
        public admin()
        {
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            gunaAnimateWindow1.Start();
            baglanti.Open();
            string sorgu0 = "Select count(urunid) as Uid From urun";
            OleDbCommand komut0 = new OleDbCommand(sorgu0, baglanti);
            OleDbDataReader cikti0 = komut0.ExecuteReader();


            while (cikti0.Read())
            {
                lbltotalmenu.Text = Convert.ToString(cikti0["Uid"]);
              

            }

            cikti0.Close();

            string sorgu = "SELECT Sum(fiyati) As toplamfiyat FROM urun INNER JOIN Sepet ON urun.urunid = Sepet.UrunNo";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            OleDbDataReader cikti = komut.ExecuteReader();


            while (cikti.Read())
            {              
                lblgelir.Text = Convert.ToString(cikti["toplamfiyat"]);
             

            }

            cikti.Close();

            string sorgu1 = "SELECT Count(kid) As kidtoplam FROM kullanici";
            OleDbCommand komut1 = new OleDbCommand(sorgu1, baglanti);
            OleDbDataReader cikti1 = komut1.ExecuteReader();
            while (cikti1.Read())
            {
               
                lblmusteri.Text = Convert.ToString(cikti1["kidtoplam"]);

            }
            cikti1.Close();

            baglanti.Close();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void gunaButton3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
               
            }            
        }

        private void gunaGradientButton6_Click(object sender, EventArgs e)
        {
            Form frm = new urunekle();
            frm.ShowDialog();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            bunifuPanel7.Visible = false;
            gunaAdvenceButton1.Size = new System.Drawing.Size(131, 42);
            gunaAdvenceButton2.Size = new Size(166, 42);
            bunifuPanel7.Visible = false;
            masakontrol1.Size = new Size(970, 554);
            masakontrol1.Location = new Point(166, 83);
            masakontrol1.Visible = true;
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            gunaAdvenceButton1.Size = new Size(166, 42);
            bunifuPanel7.Visible=true;
            masakontrol1.Visible = false;
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            Form urunler = new urunler();
            urunler.Show();
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            
            Form db = new dbYedekleme();
            db.Show();

        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            Form db = new dbYedekleme();
            db.Show();
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            string tarih = bunifuDatePicker1.Value.ToString(); //oluşturulan tarihi aldık.
            char[] ayrac = { ' ' }; //tarih verisi 7.04.2022 00:59:29 bu şekilde olduğu için bölmemiz gerekiyor. bölceğimiz nokta boşluk yeri              
            string[] parcalar = tarih.Split(ayrac); //split ile bölerek 0.dizi bizim ilk parçamız oluyor örnek çıktı parcalar[0] = 7.04.2022
           

            baglanti.Open();
            string sorgu = "SELECT Count(kid) As kidtoplam FROM kullanici WHERE tarih Like '%" + parcalar[0] + "%'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            OleDbDataReader cikti = komut.ExecuteReader();


            while (cikti.Read())
            {
                lblmusteri.Text = Convert.ToString(cikti["kidtoplam"]);
            }

            cikti.Close();
            baglanti.Close();
            
        }
    }
}
