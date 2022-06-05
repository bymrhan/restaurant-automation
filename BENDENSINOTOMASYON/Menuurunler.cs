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
    public partial class Menuurunler : Form
    {
        public string gelenid = null;
        string kid = null;
        static string baglantiyolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=restorandb.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiyolu);
        public Menuurunler()
        {
            InitializeComponent();
        }

    
            private void Menuurunler_Load(object sender, EventArgs e)
            {
               
            baglanti.Open();          
            string sorgu = "Select *From kullanici where durum=False"; //bu kullanıcını aktif mi değilmi onu sorgulayacağız.
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            OleDbDataReader cikti = komut.ExecuteReader();
              
            while (cikti.Read())
            {
                kid = Convert.ToString(cikti["kid"]);
                
            }
            
            cikti.Close();
            
            baglanti.Close();
            masadbkontrol();

            sepetlistele();



            baglanti.Open();
            OleDbDataAdapter query0 = new OleDbDataAdapter("Select *From urun where kategori="+gelenid, baglanti); //kategoriye göre ürün
            DataTable UrunDT = new DataTable();
            query0.Fill(UrunDT);

            OleDbDataAdapter query1 = new OleDbDataAdapter("Select *From urun ", baglanti); //urun tablosunu çek
            DataTable urun = new DataTable();
            query1.Fill(urun);

            OleDbDataAdapter query2 = new OleDbDataAdapter("Select *From urunkategori", baglanti); //kategori çek
            DataTable grup = new DataTable();
            query2.Fill(grup);

            for (int groupIndex = 0; groupIndex < grup.Rows.Count; ++groupIndex)
            {
                //grubları listviewe ekliyor
                this.lstUrun.Groups.Add(grup.Rows[groupIndex]["id"].ToString(), grup.Rows[groupIndex]["kategori"].ToString());

                for (int urunIndex = 0; urunIndex < UrunDT.Rows.Count; ++urunIndex)
                {
                    if (UrunDT.Rows[urunIndex]["kategori"].ToString() == grup.Rows[groupIndex]["id"].ToString())
                    {

                        if (UrunDT.Rows[urunIndex]["resim"] != null)//resim var mı diye kontrol ediyoruz resim var ise alttaki işlemler gerçekleşir.
                        {
                            try
                            {
                                Image myImage = Image.FromFile(Application.StartupPath + UrunDT.Rows[urunIndex]["resim"].ToString());//resimi alıyoruz
                                imageList1.Images.Add(UrunDT.Rows[urunIndex]["urunid"].ToString(), myImage);//resmi imageliste ekliyoruz
                            } // veri tabanındaki resmi alıyoruz imagelistin içine atıyoruz.
                            catch (Exception)
                            {                         }

                            ListViewItem item = new ListViewItem(UrunDT.Rows[urunIndex]["adi"].ToString() + "\n" + UrunDT.Rows[urunIndex]["fiyati"].ToString() + " ₺",
                                UrunDT.Rows[urunIndex]["urunid"].ToString(), this.lstUrun.Groups[groupIndex]);//Ürünü,resmi,grubu bağlıyoruz
                            this.lstUrun.Items.Insert(0, item);//ürünü ekliyor
                            this.lstUrun.Groups[groupIndex].Items.Insert(0, item);//ürünü gruba ekliyor

                        }
                        else //resimyolunda resim yoksa imagekey yinede ürünNo dan oluşturulur. imagekeyden de ürün bilgilerini çekeceğiz.
                        {

                            ListViewItem item = new ListViewItem(urun.Rows[urunIndex]["adi"].ToString() + "-" + urun.Rows[urunIndex]["fiyati"].ToString() + " ₺", urun.Rows[urunIndex]["urunid"].ToString(),
                           this.lstUrun.Groups[groupIndex]);//Ürünü,resmi,grubu bağlıyoruz
                            this.lstUrun.Items.Insert(0, item);//ürünü ekliyor
                        }

                    }

                }
            }
            baglanti.Close();
            }
        public void sepetlistele() 
        {          
            lstSepet.Items.Clear();
            OleDbDataAdapter query0 = new OleDbDataAdapter("SELECT urun.urunid,adi,fiyati,kategori,resim,calori,aciklama,SiparisUrunNo FROM urun INNER JOIN Sepet ON urun.urunid = Sepet.UrunNo WHERE Sepet.kid=" + kid + "", baglanti);
            DataTable UrunDT = new DataTable();
            query0.Fill(UrunDT);

            OleDbDataAdapter query1 = new OleDbDataAdapter("Select *From urun ", baglanti);
            DataTable urun = new DataTable();
            query1.Fill(urun);

            OleDbDataAdapter query2 = new OleDbDataAdapter("Select *From urunkategori", baglanti);
            DataTable grup = new DataTable();
            query2.Fill(grup);

            for (int groupIndex = 0; groupIndex < grup.Rows.Count; ++groupIndex)
            {
                //grubları listviewe ekliyor
                this.lstSepet.Groups.Add(grup.Rows[groupIndex]["id"].ToString(), grup.Rows[groupIndex]["kategori"].ToString());

                for (int urunIndex = 0; urunIndex < UrunDT.Rows.Count; ++urunIndex)
                {
                    if (UrunDT.Rows[urunIndex]["kategori"].ToString() == grup.Rows[groupIndex]["id"].ToString())
                    {


                        if (UrunDT.Rows[urunIndex]["resim"] != null)//resimyolunda resim var mı diye kontrol ediyoruz
                        {
                            try
                            {
                                Image myImage = Image.FromFile(Application.StartupPath + UrunDT.Rows[urunIndex]["resim"].ToString());//resimi alıyoruz
                                imageList1.Images.Add(UrunDT.Rows[urunIndex]["urunid"].ToString(), myImage);//resmi imageliste ekliyoruz
                            }
                            catch (Exception)
                            {



                            }



                            ListViewItem item = new ListViewItem(UrunDT.Rows[urunIndex]["adi"].ToString() + "\n" + UrunDT.Rows[urunIndex]["fiyati"].ToString() + " ₺",
                                UrunDT.Rows[urunIndex]["urunid"].ToString(), this.lstSepet.Groups[groupIndex]);//Ürünü,resmi,grubu bağlıyoruz
                            this.lstSepet.Items.Insert(0, item);//ürünü ekliyor
                           
                            this.lstSepet.Groups[groupIndex].Items.Insert(0, item);//ürünü gruba ekliyor
                          
                        }
                        else //resimyolunda resim yoksa imagekey yinede ürünNo dan oluşturulur. imagekeyden de ürün bilgilerini çekeceğiz.
                        {

                            ListViewItem item = new ListViewItem(urun.Rows[urunIndex]["adi"].ToString() + "-" + urun.Rows[urunIndex]["fiyati"].ToString() + " ₺", urun.Rows[urunIndex]["urunid"].ToString(),
                           this.lstSepet.Groups[groupIndex]);//Ürünü,resmi,grubu bağlıyoruz
                            this.lstSepet.Items.Insert(0, item);//ürünü ekliyor
                        }

                    }

                }
            }
            baglanti.Close();
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            timer1.Start();

            if (lstUrun.SelectedItems.Count > 0)
            {
                foreach (ListViewItem seciliItem in lstUrun.SelectedItems)
                {               
                    baglanti.Open();  
                                     
                            string veri = "insert into Sepet(UrunNo,UrunAdet,kid) values (@UrunNo,@UrunAdet,@kid)";
                            OleDbCommand komut = new OleDbCommand(veri, baglanti);
                            komut.Parameters.AddWithValue("@UrunNo", seciliItem.ImageKey);
                            komut.Parameters.AddWithValue("@UrunAdet", "1");
                            komut.Parameters.AddWithValue("@kid", kid);
                            komut.ExecuteNonQuery();

                    baglanti.Close();                  
                }
            }
            sepetlistele();
        }
        
        public void masadbkontrol()
        {
            string masano;
            baglanti.Open();
            string sorgu = "Select *From kullanici where durum=False and kid=" + kid + "";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            OleDbDataReader cikti = komut.ExecuteReader();

           
            while (cikti.Read())
            {               
                masano = Convert.ToString(cikti["MasaNo"]);
                if (masano != "")
                { }
                else
                {
                    MessageBox.Show("Masa Seçimi henüz yapmadınız.");
                    Form1 fr = (Form1)Application.OpenForms["Form1"];                
                    fr.masakontrolsonuc = "1";
                    this.Close();
                }
               
            }

            cikti.Close();

            baglanti.Close();
            
        }

        private void btnsepetsil_Click(object sender, EventArgs e)
        {
           
            if (lstSepet.SelectedItems.Count > 0)
            {
                DialogResult c;
                c = MessageBox.Show("Sepetten çıkarmak istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    foreach (ListViewItem seciliItem in lstSepet.SelectedItems)
                    {
                        baglanti.Open();
                        OleDbCommand komut = new OleDbCommand();
                        komut.Connection = baglanti;
                        string secilenid = seciliItem.ImageKey;

                       
                        string sorgu = "SELECT TOP 1 * FROM Sepet WHERE kid=" + kid + " And UrunNo=" + secilenid; 
                        //her seferinde tek ürün sipariş nosu çekeren 1 adet ürünün silinmesini sağladık.
                        OleDbCommand sipsorgu = new OleDbCommand(sorgu, baglanti);
                        OleDbDataReader cikti1 = sipsorgu.ExecuteReader();
                       
                        while (cikti1.Read())
                        {
                           string sipno = Convert.ToString(cikti1["SiparisUrunNo"]);
                            komut.CommandText = "Delete from Sepet where SiparisUrunNo=" + sipno;
                            DataSet ds = new DataSet();
                            komut.ExecuteNonQuery();
                           

                        }
                            komut.Dispose();
                            baglanti.Close();
                            cikti1.Close();                                     
                    }
                    sepetlistele();
                }
            }
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "SELECT Sum(fiyati)As toplamfiyat,Sum(UrunAdet) As toplamurunadet FROM urun INNER JOIN Sepet ON urun.urunid = Sepet.UrunNo WHERE Sepet.kid=" + kid;
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            OleDbDataReader cikti = komut.ExecuteReader();
            while (cikti.Read())
            {
                txtToplam.Text = Convert.ToString(cikti["toplamfiyat"]);
                txttoplamurun.Text = Convert.ToString(cikti["toplamurunadet"]);

            }

            cikti.Close();
            baglanti.Close();
        }

        private void btnodeme(object sender, EventArgs e)
        {
            Form1 fr = (Form1)Application.OpenForms["Form1"];
            fr.masakontrolsonuc = "3";
            
        }
    }
}

