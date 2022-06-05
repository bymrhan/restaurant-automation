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
    public partial class masakontrol : UserControl
    {
        public string gelenid = null;
        static string baglantiyolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=restorandb.mdb";
        string kid = null;
        static OleDbConnection baglanti = new OleDbConnection(baglantiyolu);
        public masakontrol()
        {
            InitializeComponent();
        }

        private void masakontrol_Load(object sender, EventArgs e)
        {
            timer1.Start();
            baglanti.Open();
            string sorgu = "Select *From kullanici where durum=False";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            OleDbDataReader cikti = komut.ExecuteReader();
            while (cikti.Read())
            {
                kid = Convert.ToString(cikti["kid"]);
            }
            cikti.Close();
            baglanti.Close();
            btnT1.Visible = false;
            btnT3.Visible = false;
            btnT5.Visible = false;
            btnT2.Visible = false;
            btnT4.Visible = false;
            btnT6.Visible = false;
        }

        private void masakontrol_MouseHover(object sender, EventArgs e)
        {
            
            
            btnT1.Visible = false;
            btnT3.Visible = false;
            btnT5.Visible = false;
            btnT2.Visible = false;
            btnT4.Visible = false;
            btnT6.Visible = false;


        }

        private void bunifuPictureBox1_MouseHover(object sender, EventArgs e)
        {
            btnT1.Visible = true;
            btnT3.Visible = false;
            btnT5.Visible = false;
            btnT2.Visible = false;
            btnT4.Visible = false;
            btnT6.Visible = false;
           

        }

        private void bunifuPictureBox3_MouseHover(object sender, EventArgs e)
        {

            btnT1.Visible = false;
            btnT3.Visible = true;
            btnT5.Visible = false;
            btnT2.Visible = false;
            btnT4.Visible = false;
            btnT6.Visible = false;

        }

        private void bunifuPictureBox5_MouseHover(object sender, EventArgs e)
        {

            btnT1.Visible = false;
            btnT3.Visible = false;
            btnT5.Visible = true;
            btnT2.Visible = false;
            btnT4.Visible = false;
            btnT6.Visible = false;

        }

        private void bunifuPictureBox4_MouseHover(object sender, EventArgs e)
        {
            btnT1.Visible = false;
            btnT3.Visible = false;
            btnT5.Visible = false;
            btnT2.Visible = false;
            btnT4.Visible = true;
            btnT6.Visible = false;
        }

        private void bunifuPictureBox6_MouseHover(object sender, EventArgs e)
        {
            btnT1.Visible = false;
            btnT3.Visible = false;
            btnT5.Visible = false;
            btnT2.Visible = false;
            btnT4.Visible = false;
            btnT6.Visible = true;
        }

        private void bunifuPictureBox2_MouseHover(object sender, EventArgs e)
        {
            btnT1.Visible = false;
            btnT3.Visible = false;
            btnT5.Visible = false;
            btnT2.Visible = true;
            btnT4.Visible = false;
            btnT6.Visible = false;
        }

        private void geri_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnT1_Click(object sender, EventArgs e)
        {
            string masano = "T1";
            masadoldur(masano);
        }

        private void btnT3_Click(object sender, EventArgs e)
        {
            string masano = "T3";
            masadoldur(masano);
        }

        private void btnT5_Click(object sender, EventArgs e)
        {
            string masano = "T5";
            masadoldur(masano);
        }

        private void btnT2_Click(object sender, EventArgs e)
        {
            string masano = "T2";
            masadoldur(masano);
        }

        private void btnT4_Click(object sender, EventArgs e)
        {
            string masano = "T4";
            masadoldur(masano);
        }

        private void btnT6_Click(object sender, EventArgs e)
        {
            string masano = "T6";
            masadoldur(masano);
            
        }

        public void masadoldur(string masano)
        {
            baglanti.Open();
            
            string veri = "update kullanici set MasaNo = msno where kid = " + kid;
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@msno", masano);
            komut.ExecuteNonQuery();
            MessageBox.Show("Masa Seçimi Başarılı.");
            baglanti.Close();
            Form1 fr = (Form1)Application.OpenForms["Form1"];
            fr.masakontrolsonuc = "2";

        }

        public void masadolumu()
        {
            btndurumyazit1.Text = "Uygun";
            btndurumyazit2.Text = "Uygun";
            btndurumyazit3.Text = "Uygun";
            btndurumyazit4.Text = "Uygun";
            btndurumyazit5.Text = "Uygun";
            btndurumyazit6.Text = "Uygun";
            btndurumt1.BackColor = Color.Lime;
            btndurumt2.BackColor = Color.Lime;
            btndurumt3.BackColor = Color.Lime;
            btndurumt4.BackColor = Color.Lime;
            btndurumt5.BackColor = Color.Lime;
            btndurumt6.BackColor = Color.Lime;

            List<string> masalar = new List<string>();
            if (baglanti.State == ConnectionState.Closed)
            {
                try
                {
                    baglanti.Open();
                }
                catch
                {


                }
            }
            string sorgu = "SELECT MasaNo FROM kullanici WHERE durum=False";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            OleDbDataReader cikti = komut.ExecuteReader();
            while (cikti.Read())
            {
                masalar.Add(Convert.ToString(cikti["MasaNo"]));
            }
            cikti.Close();
            baglanti.Close();

            foreach (string s in masalar)
            {

                if (s == "T1")
                {
                    btnT1.Enabled = false;
                    btndurumt1.BackColor = Color.DodgerBlue;
                    btndurumyazit1.Text = "Dolu";
                }
                else if (s == "T2")
                {
                    btnT2.Enabled = false;
                    btndurumt2.BackColor = Color.DodgerBlue;
                    btndurumyazit2.Text = "Dolu";
                }
                else if (s == "T3")
                {
                    btnT3.Enabled = false;
                    btndurumt3.BackColor = Color.DodgerBlue;
                    btndurumyazit3.Text = "Dolu";
                }
                else if (s == "T4")
                {
                    btnT4.Enabled = false;
                    btndurumt4.BackColor = Color.DodgerBlue;
                    btndurumyazit4.Text = "Dolu";
                }
                else if (s == "T5")
                {
                    btnT5.Enabled = false;
                    btndurumt5.BackColor = Color.DodgerBlue;
                    btndurumyazit5.Text = "Dolu";
                }
                else if (s == "T6")
                {
                    btnT6.Enabled = false;
                    btndurumt6.BackColor = Color.DodgerBlue;
                    btndurumyazit6.Text = "Dolu";
                }



            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            masadolumu();
        }
    }
}
