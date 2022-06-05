using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BENDENSINOTOMASYON
{
    public partial class odeme : UserControl
    {
        static string baglantiyolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=restorandb.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiyolu);
        string kid = null;
        string masano = null;
        public odeme()
        {
            InitializeComponent();
        }
      
        private void odeme_Load(object sender, EventArgs e)
        {
          baglanti.Open();

            

            string sorgu1 = "Select *From kullanici where durum=False";
            OleDbCommand komut1 = new OleDbCommand(sorgu1, baglanti);
            OleDbDataReader cikti1 = komut1.ExecuteReader();


            while (cikti1.Read())
            {
                kid = Convert.ToString(cikti1["kid"]); //kullanıcı id Yİ ALDIK
                masano = Convert.ToString(cikti1["MasaNo"]); //kullanıcının masa nosunu aldık

            }

            cikti1.Close();

            // ödemesi yapılan ürünlerin
            // Artık sepetteki verileri bir bütün şeklinde veri tabanına kaydını yapacağız
            // bunun için önce tarihi masanoyu kid ekleyeceğiz.
            string veri = "insert into siparis(tarih,MasaNo,kid) values (@tarih,@Masano,@kid)";
            OleDbCommand komut0 = new OleDbCommand(veri, baglanti);
            komut0.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToOADate());
            komut0.Parameters.AddWithValue("@Masano", masano);
            komut0.Parameters.AddWithValue("@kid", kid);
            komut0.ExecuteNonQuery();

            string sorgu3 = "Select *From siparis where kid="+kid;
            OleDbCommand komut3 = new OleDbCommand(sorgu3, baglanti);
            OleDbDataReader cikti3 = komut3.ExecuteReader();
            while (cikti3.Read())
            {
                lblfisno.Text = Convert.ToString(cikti3["SiparisNo"]); //oluşturulan sipnoyu aldık lblfisnoya yazdık.         
                string tarih = Convert.ToString(cikti3["tarih"]); //oluşturulan tarihi aldık.
                char[] ayrac = {' '}; //tarih verisi 7.04.2022 00:59:29 bu şekilde olduğu için bölmemiz gerekiyor. bölceğimiz nokta boşluk yeri              
                string[] parcalar = tarih.Split(ayrac); //split ile bölerek 0.dizi bizim ilk parçamız oluyor örnek çıktı parcalar[0] = 7.04.2022
                lbltarih.Text = parcalar[0];
            }
            cikti3.Close();


            string sorgu = "SELECT Sum(fiyati)As toplamfiyat,Sum(UrunAdet) As toplamurunadet FROM urun INNER JOIN Sepet ON urun.urunid = Sepet.UrunNo WHERE Sepet.kid=" + kid;
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            OleDbDataReader cikti = komut.ExecuteReader();
            while (cikti.Read())
            {
                lbltoplam.Text = Convert.ToString(cikti["toplamfiyat"] + " ₺");             
            }

            cikti.Close();

            
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT adi,Sum(UrunAdet) As urunadet,Sum(fiyati) As urunfiyat FROM urun INNER JOIN Sepet ON urun.urunid = Sepet.UrunNo WHERE Sepet.kid=" + kid + " GROUP By adi", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            
            dataGridView1.DataSource = tablo;
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[1].Width = 80;

            string sorgu2 = "Select *From kullanici where durum=False and kid=" + kid + "";
            OleDbCommand komut2 = new OleDbCommand(sorgu2, baglanti);
            OleDbDataReader cikti2 = komut2.ExecuteReader();

            while (cikti2.Read())
            {
               string masano = Convert.ToString(cikti2["MasaNo"]);
                lblmasano.Text = masano;
                
            }

            cikti2.Close();
            baglanti.Close();
        }
        
      
        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            gunaLabel1.Text = "";
            if (bunifuTextBox1.Text.Length < 16)
            {
                Int64 sayi = Convert.ToInt64(bunifuTextBox1.Text);
                Int64 basamak = 0;
                for (int i = 0; i < bunifuTextBox1.Text.Length; i++)
                {
                    basamak = sayi % 10;
                    sayi = sayi / 10;

                    if (i < 4)
                    {
                        gunaLabel1.Text += basamak.ToString();
                    }

                }
            }
            else
            {
                MessageBox.Show("Dikkat!", "Kart numaranızı kontrol ediniz.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtad_TextChange(object sender, EventArgs e)
        {
            lblkartad.Text = txtad.Text;
        }

        private void txtmail_TextChange(object sender, EventArgs e)
        {
            
        }

        private void txtsontarih_TextChange(object sender, EventArgs e)
        {
            lblkarttarih.Text = txtsontarih.Text;
        }

        private void gunaAdvenceButton1_Click_1(object sender, EventArgs e)
        {
        

        }
    }
}
