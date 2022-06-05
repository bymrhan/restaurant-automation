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
    public partial class Form1 : Form
    {
        public string masakontrolsonuc = "";
        static string baglantiyolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=restorandb.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiyolu);
        public Form1()
        {
            InitializeComponent();
            //timer1.Start();
            resimler.Start();
            timer2.Start();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string veri = "update kullanici set durum = @durum";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.Add("@durum", OleDbType.Boolean, 1, "[durum]").Value = true;

            komut.ExecuteNonQuery();
            baglanti.Close();
            this.Close();
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            
           bunifuRating1.Visible=false;
           gunaGradientButton1.Visible=false;
           gunaPanel1.Visible=false;
           odeme1.Visible=false;
           gunaTransfarantPictureBox1.Visible = false;
           gunaAdvenceButton2.Visible = false;
           kategori1.Visible = true;
            masakontrol1.Visible = false;
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (kategori1.Visible == false && masakontrol1.Visible == false)
            {
                gunaTransfarantPictureBox1.Visible = true;
                bunifuRating1.Visible = true;
                gunaAdvenceButton2.Visible = true;
            }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            kategori1.Visible=false;
            odeme1.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            gunaAnimateWindow1.Start();
            baglanti.Open();
            string veri = "insert into kullanici(tarih) values (@tarih)";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToOADate());

            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            masakontrol1.Visible = true;
            kategori1.Visible = false;
            gunaTransfarantPictureBox1.Visible = false;
            bunifuRating1.Visible = false;          
            gunaAdvenceButton2.Visible = false;
            masakontrol1.Visible=true;

        }

   

        private void resimler_Tick(object sender, EventArgs e)
        {
            if (kategori1.Visible == false && masakontrol1.Visible == false && odeme1.Visible== false)
            {
                                 
            if (gunaTransfarantPictureBox1.Visible == true)
            {
                   
                    gunaGradientButton1.Visible = true;
                    gunaGradientButton1.BringToFront();
                    bunifuRating1.Visible = false;
                    gunaAdvenceButton2.Visible = false;
                    gunaTransfarantPictureBoxresim2.Location = new System.Drawing.Point(139, 61);
                gunaTransfarantPictureBox1.Visible=false;
                bunifuTransition2resim2.ShowSync(gunaTransfarantPictureBoxresim2);
                gunaTransfarantPictureBoxresim2.Visible = true;
                    gunaPanel1.BringToFront();
                    bunifuTransition1.ShowSync(gunaPanel1);
                    gunaPanel1.Visible = true;
                    

                }
            else
            {
                    gunaPanel1.Visible = false;
                    gunaGradientButton1.Visible = false;
                    gunaTransfarantPictureBoxresim2.Visible = false;
                bunifuTransition1.ShowSync(gunaTransfarantPictureBox1);
                gunaTransfarantPictureBox1.Visible=true;
                    bunifuRating1.Visible = true;
                    gunaAdvenceButton2.Visible = true;


                }
            }

        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            odeme1.Visible = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (masakontrolsonuc == "1") //eğer 1 ise
            {
                kategori1.Visible = false;
                masakontrol1.Visible = true; //masa seçim ekranını görüntüle
                masakontrolsonuc = "0";
            }
            if (masakontrolsonuc == "2") //eğer 2 ise
            {
                kategori1.Visible = true;
                masakontrol1.Visible = false; //masa seçimi kapat kategori seçimi getir.
                masakontrolsonuc = "0";
            }

            if(masakontrolsonuc == "3")
            {
                kategori1.Visible = false;
                odeme1.Visible=true;
                masakontrolsonuc="0";
                Menuurunler fr = (Menuurunler)Application.OpenForms["Menuurunler"];
                fr.Close();

            }
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            admin admin = new admin();   
            admin.Show();
           

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            bunifuRating1.Visible = false;
            gunaGradientButton1.Visible = false;
            gunaPanel1.Visible = false;
            odeme1.Visible = false;
            gunaTransfarantPictureBox1.Visible = false;
            gunaAdvenceButton2.Visible = false;
            kategori1.Visible = true;
            masakontrol1.Visible = false;
        }
    }
}
